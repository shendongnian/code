    [FooAspect(AttributeTargetMembers = "Property*")]
    public class Foo
    {        
        public string Property1 { get; set; }    
        public string Property2 { get; set; }
        public string Property30 { get; set; }
        public string Property31 { get; set; }
                
        public Dictionary<string, object> Properties {get; set; }
    }
