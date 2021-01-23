    public class MyService{
        public Guid Id {get;set;}
        public string ServiceName {get;set;}
        public Guid PersonId {get;set;}
    }
    public class Person
    {
        public Guid  Id { get; set; }
        public String Name { get; set; }
        public virtual IList<MyService> ServiceNeeded { get; set; }
    }
