    class Derived : Base
    {
        public static Derived()
        {
            Factory.Register(typeof(Derived));
        }
    }
    
    // this could also be done with generics rather than Type class
    class Factory
    {
        public static Register(Type t)
        {
            RegisteredTypes[t.Name] = t;
        }
        protected Dictionary<string, Type t> RegisteredTypes;
    
        public static Base Instantiate(string typeName)
        {
            if (!RegisteredTypes.ContainsKey(typeName))
                return null;
            return (Base) Activator.CreateInstance(RegisteredTypes[typeName]);
        }
    }
