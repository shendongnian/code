    public static class TypeToString<Type>
    {
        private Lazy<Dictionary<Type, string>> storage = new Lazy<Dictionary<Type, string>>(GetMap);
        protected abstract Dictionary<Type, string> GetMap();
        public string Get(Type t) {return storage[t];}
    }
    public static class MyEnumToString : TypeToString<MyEnum>
    {
        protected virtual Dictionary<Type, string> GetMap()
        {
            //Code here
        }
    }
