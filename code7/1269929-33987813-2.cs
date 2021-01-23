    namespace CodeFirst.Model
    {
        using System.Collections.Generic;
        public class Motorcycle
        {
            public int MotorcycleId { get; set; }
            public int ModelYear { get; set; }
            public int Displacement { get; set; }
            public decimal Killowatts { get; set; }
            public string ModelName { get; set; }
            public virtual ICollection<Person> Persons { get; set; }
        }
    }
    namespace CodeFirst.Model
    {
        public class Person
        {
            public int PersonId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public virtual Motorcycle Motorcycle { get; set; }
            [ForeignKey("Motorcycle")]
            public int MotorcycleId { get; set; }
        }
    }
