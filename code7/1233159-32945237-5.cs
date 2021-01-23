    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class PropertyDeclaringTypeAttribute : Attribute
    {
        public PropertyDeclaringTypeAttribute(Type declaringType)
        {
            DeclaringType = declaringType;
        }
        public Type DeclaringType { get; private set; }
    }
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class PropertyNameAttribute : Attribute
    {
        public PropertyNameAttribute(string name)
        {
            Name = name;
        }
        public string Name { get; private set; }
    }
