    public class Event     
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<Person> Persons { get; set; }
    }
    public class Company
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
