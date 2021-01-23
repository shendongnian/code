    public abstract class TypeToString<Type>
    {
        protected TypeToString()
    	{
    	    storage = new Lazy<Dictionary<Type, string>>(GetMap);
    	}
        private Lazy<Dictionary<Type, string>> storage;
        protected abstract Dictionary<Type, string> GetMap();
        public string Get(Type t) {return storage.Value[t];}
    }
    public class MyEnumToString : TypeToString<MyEnum>
    {
        protected override Dictionary<MyEnum, string> GetMap()
        {
            return null;
        }
    }
