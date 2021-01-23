    public class Generator
    {
        private Random rnd = new Random();
        // Make it so you only have to get the interfaces for a given type once.
        private Dictionary<Type, List<Type>> _typeCache = new Dictionary<Type, List<Type>>();
        public T GetRandomObject<T>()
        {
            List<Type> types = GetTypes<T>();
            int index = rnd.Next(types.Count);
            return (T)Activator.CreateInstance(types[index]);
        }
        private List<Type> GetTypes<T>()
        {
            List<Type> types;
            if (!_typesCache.TryGetValue(typeof(T), out types))
            {
                //can't a generic type constraint that says "implements any interface" so I use this ugly thing...
                if (!typeof(T).IsInterface)
                    throw new Exception("Generator needs to be instanciated with an interface generic parameter");
                types = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.GetInterfaces().Contains(typeof(T))).ToList();
                _typesCache[typeof(T)] = types;
            }
            return types;
        }
    }
