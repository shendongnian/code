    public class RegController : ApiController
    {
       //now insert  these values into the DB
        public void addUser(Person item)
        {
                ...
       
        }
        public class Person
       {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
