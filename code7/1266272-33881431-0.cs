    [DataContract]
    public class ClassA
    {
        public ClassB MyData { get; set; }
    
        public string SomeString { get; set; }
    
        public int SomeNumber { get; set; }
    
    }
    
    public class ClassB
    {
        public string SomeOtherInfo { get; set; }
    
        public int SomeOtherNumber { get; set; }
    }
