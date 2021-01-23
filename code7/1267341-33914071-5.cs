    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new SampleDbContext())
            {
                Console.WriteLine("Creating John McFlanagan and their 2 vehicles");
                var person = new Person {Name = "John McFlanagan"};
                var vehicle1 = new Vehicle { Person = person, Model = "Vauxhall Astra" };
                var vehicle2 = new Vehicle { Person = person, Model = "Ford Capri" };
                ctx.Vehicles.AddRange(new[] {vehicle1, vehicle2});
                ctx.SaveChanges();
            }
            using (var ctx = new SampleDbContext())
            {
                var person = ctx.Persons.First();
                // Loading related vehicles in the context
                ctx.Vehicles.Where(v => v.PersonId == person.PersonId).Load();
                Console.WriteLine("Deleting the person, and nullifying vehicles PersonId");
                ctx.Persons.Remove(person);
                ctx.SaveChanges();
            }
        }
    }
