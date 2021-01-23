    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    
    namespace SOSample
    {
        public class list
        {
            public int id { get; set; }
            public List<Users> UsersList { get; set; }
    
            public class Users
            {
                [Key]
                public int Users_id { get; set; }
                public string UserId { get; set; }
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                // Instantiate and initialize with sample data.
                var sampleList = new list()
                {
                    id = 12345,
                    UsersList = new List<list.Users>()
                    {
                        new list.Users() { Users_id = 1, UserId = "0042" },
                        new list.Users() { Users_id = 2, UserId = "0019" },
                        new list.Users() { Users_id = 3, UserId = "0036" },
                        new list.Users() { Users_id = 4, UserId = "0214" },
                        new list.Users() { Users_id = 5, UserId = "0042" },
                        new list.Users() { Users_id = 6, UserId = "0042" },
                        new list.Users() { Users_id = 7, UserId = "0019" }
                    }
                };
    
                // Linq search.
                var someId = "0042";
                var linqQuery = sampleList.UsersList.Where(user => user.UserId == someId);
    
                Console.WriteLine("Linq query results:");
                foreach (var r in linqQuery)
                {
                    Console.WriteLine($"Users_id: {r.Users_id}, UserId: {r.UserId}");
                }
    
                // Lookup search (using same someId as for Linq).
                var lookup = sampleList.UsersList.ToLookup(user => user.UserId);
                var lookupQuery = lookup[someId];
    
                Console.WriteLine("\nLookup query results:");
                foreach (var r in lookupQuery)
                {
                    Console.WriteLine($"Users_id: {r.Users_id}, UserId: {r.UserId}");
                }
            }
        }
    }
