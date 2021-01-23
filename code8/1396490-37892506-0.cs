    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class ResourceAttribute : Attribute
    {
        public ResourceAttribute(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }
        public string Name { get; private set; }
        public string Value { get; private set; }
    }
