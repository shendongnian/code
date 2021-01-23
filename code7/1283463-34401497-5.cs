    namespace MyNamespace.MyProject.Service.Models
    {
        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            //The service contract expects username to be a string.
            public string UserName { get; set; }
        }
    }
