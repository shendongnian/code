    public interface IFoo
    {
        string field1 { get; set; }
        string field2 { get; set; }
        string field3 { get; set; }
        //etc...
    }
    
    public class A : IFoo
    {
        public string field1 { get; set; }
        public string field2 { get; set; }
        public string field3 { get; set; }
        //...etc
        public string anotherA1 { get; set; }
        public string anotherA2 { get; set; }
    }
    
    public class B : IFoo
    {
        public string field1 { get; set; }
        public string field2 { get; set; }
        public string field3 { get; set; }
        //...etc
        public string anotherB1 { get; set; }
        public string anotherB2 { get; set; }
    }
