    public class Factory
    {
        public static Factory Instance { get { return _instance; } }
    
        private static Factory _instance = new Factory();
        private Factory() { }
    
        static Dictionary<string, Type> _registeredType = new Dictionary<string, Type>();
    
        public void Register<T>(string id)
        {
            var type = typeof(T);
            if (type.IsAbstract || type.IsInterface)
                throw new ArgumentException("Cannot create instance of interface or abstract class");
    
            _registeredType.Add(id, type);
        }
    
        public T Create<T>(string id, params object[] parameters)
        {
            Type type;
    
            if(!_registeredType.TryGetValue(id, out type))
                throw new UnsupportedShapeException(id);
    
            return (T) Activator.CreateInstance(type, parameters);
        }
    } 
