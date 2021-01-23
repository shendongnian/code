    namespace personToDictionary
    {
        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public Address Address { get; set; }
    
            public Dictionary<string, string> ToDictionary()
            {
                return new Dictionary<string, string>
                {
                    {"FirstName", FirstName},
                    {"LastName", LastName},
                    {"Address.Street", Address.Street},
                    {"Adress.PostalCode", Address.PostalCode.ToString()}
                };
            } 
        }
    
        public class Address
        {
            public string Street { get; set; }
            public int PostalCode { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var person = new Person
                {
                    FirstName = "Jon",
                    LastName = "Doe",
                    Address = new Address
                    {
                        Street = "Melkbos",
                        PostalCode = 90210
                    }
                };
                var personDictionary = person.ToDictionary();
            }
        }
    }
