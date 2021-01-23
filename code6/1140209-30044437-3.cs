    public class BaseClass
    {
        Dictionary<Type, object> propertys = new Dictionary<Type, object>();
        public void Add<T>(T instance)
        {
            propertys[typeof(T)] = instance;
        }
        public T Get<T>()
        {
            return (T)propertys[typeof(T)];
        }
        public void Test()
        {
            Add<string>("Hello World");
            string helloWorld = Get<string>();
        }
    }
