    public abstract class Person
    {
        public int Id { get; set; }
    }
    [Table("Clients")]
    public class Client : Person
    {
    }
    [Table("Functionaries")]
    public class Functionary : Person
    {
    }
