    public abstract class MyBaseClass<T> where T : class, new()
    {
        protected static ConcurrentDictionary<object, T> Instances = 
            new ConcurrentDictionary<object, T>();
        public static T Instance(object key)
        {
            return Instances.GetOrAdd(key, obj => new T());
        }
        public abstract int Demo();
    }
    public class MyClass : MyBaseClass<MyClass>
    {
        public override int Demo() { return 1; }
    }
    public class MyOtherClass : MyBaseClass<MyOtherClass>
    {
        public override int Demo() { return 2; }
    }
