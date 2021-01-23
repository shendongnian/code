    public class NameAttribute : Attribute
    {
        public NameAttribute(string name) 
        {
             Name = name;
        }
    
        public string Name { get; }
    }
   
    [Name("Custom name")]
    public class A
    {
    }
