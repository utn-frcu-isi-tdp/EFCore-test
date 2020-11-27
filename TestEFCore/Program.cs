using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTest
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var db = new AgendaContext())
            {

                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                // Alta
                Persona mPersona = new Persona
                {
                    
                    Nombre = "Juan",
                    Apellido = "Sánchez",
                    Telefonos = new List<Telefono>{ new Telefono { 
                                                                    Numero = "555-123456",
                                                                    Tipo = "Celular" } }
                };            
                db.Personas.Add(mPersona);
                db.SaveChanges();

                // busqueda
                foreach (var item in db.Personas)
                {
                    Console.WriteLine("Persona encontrada Nombre:{0}, Apellido: {1}, IdPersona:{2}",
                                       item.Nombre,
                                       item.Apellido,
                                       item.PersonaId);
                }
                Console.ReadKey();
            }
        }
    }
}
