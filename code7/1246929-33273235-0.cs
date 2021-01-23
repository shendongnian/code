    public class ServiceLocator
    {
        public static ServiceLocator Instance = new ServiceLocator();
        private ServiceLocator()
        {
        }
        private readonly IDictionary<Type, Type> TypeMap = new Dictionary<Type, Type>();
        private readonly IDictionary<Type, object> TypeMapInstances = new Dictionary<Type, object>();
        public void Register<TInterface, TClass>()
        {
            TypeMap.Add(typeof(TInterface), typeof(TClass));
        }
        public void Register<TClass>(object instance)
        {
            TypeMapInstances.Add(typeof(TClass), instance);
        }
        public T GetService<T>()
        {
            Type type = typeof(T);
            object resolvedType = null;
            try
            {
                if (TypeMapInstances.ContainsKey(type))
                {
                    resolvedType = TypeMapInstances[type];
                }
                else
                {
                    resolvedType = Activator.CreateInstance(TypeMap[type]);
                    TypeMapInstances.Add(type, resolvedType);
                }
            }
            catch (Exception)
            {
                return default(T);
                //throw new Exception(string.Format("Could not resolve type {0}", type.FullName));
            }
            return (T)resolvedType;
        }
    }
