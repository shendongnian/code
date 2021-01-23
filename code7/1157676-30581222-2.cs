    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class Parent
    {
        public User Users { get; set; }
        public Parent() { }
       
    }
