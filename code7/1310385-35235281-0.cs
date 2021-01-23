    [System.AttributeUsage(System.AttributeTargets.Class,
                       AllowMultiple = true)  // Multiuse attribute.]
    public class RegistryKey : System.Attribute
    {
        public string Name {get; private set;}
        public string Type {get; private set;}
        public string Data {get; private set;}
        public RegistryKey(string name, string type, string data)
        {
            Name = name;
            Type = type;
            Data = data;
        }
    }
