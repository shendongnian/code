    public class Names
    {
        public string @string { get; set; }
    }
    
    public class Type
    {
        public string TypeId { get; set; }
        public string TypeName { get; set; }
    }
    
    public class ClassTypes
    {
        public List<Type> Types { get; set; }
    }
    
    public class MyClass
    {
        public int Id { get; set; }
        public Names Names { get; set; }
        public ClassTypes ClassTypes { get; set; }
        public string Status { get; set; }
        public string DOB { get; set; }
    }
