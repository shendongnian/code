    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>()
            {
                new User() { UserId = 42, Name = "Abc" },
                new User() { UserId = 43, Name = "Pqr" },
                new User() { UserId = 44, Name = "lmn" },
                new User() { UserId = 45, Name = "xyz" },
            };
            List<UserMapping> userMappings = new List<UserMapping>()
            {
                new UserMapping() { MappingId = 1, User1 = 42, User2 = 43},
                new UserMapping() { MappingId = 2, User1 = 42, User2 = 44},
                new UserMapping() { MappingId = 3, User1 = 43, User2 = 44},
            };
            var data = (from u in users
                            join m in userMappings on u.UserId equals m.User2
                            where !(from mm in userMappings
                                   select mm.User1).Contains(u.UserId)
                            select u).Distinct();
            foreach(var entry in data)
            {
                Console.WriteLine(entry.UserId + " " + entry.Name);
            }
            Console.ReadLine();
        }
    }
    class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
    }
    class UserMapping
    {
        public int MappingId { get; set; }
        public int User1 { get; set; }
        public int User2 { get; set; }
    }
