    [AttributeUsage(AttributeTargets.Assembly)]
    public class AssemblyMyCustomAttribute : Attribute
    {
        public string Value { get; private set; }
    
        public AssemblyMyCustomAttribute() : this("") { }
        public AssemblyMyCustomAttribute(string value) { Value = value; }
    }
