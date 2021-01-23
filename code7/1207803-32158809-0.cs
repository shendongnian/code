     public class DataService
    {
        public static MongoRepository<ModelClass> ModelClass{ get { return Singleton<MongoRepository<ModelClass>>.Instance; } }
    }
    public class Singleton<T> where T : class, new()
    {
        Singleton() { }
        private static readonly Lazy<T> instance = new Lazy<T>(() => new T());
        public static T Instance { get { return instance.Value; } }
    }
