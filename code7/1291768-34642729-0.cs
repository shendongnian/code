    public class Person : Registered
    {
        public int ID { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
    }
    public class Registered
    {
        public DateTime DateOfRegister { set; get; }
    }
