    public class Person
    {
       public string Name { get; set; }
       public List<Child> Children { get; set; }
    }
    public class Parent : Person
    {
       // Probably this class would contain something useful
    }
    
    public class Child : Person
    {
        public Person ParentPerson { get; set; }
    }
