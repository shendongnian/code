        public class Person
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string Surname { get; set; }
            public virtual User User { get; set; }
        }
        public class User
        {
            public int Id { get; set; }
            public string LoginName { get; set; }
            public string Password { get; set; }
        }
