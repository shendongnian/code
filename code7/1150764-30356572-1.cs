    public abstract class A<TC> where TC : class, new()
    {
        protected static ConcurrentDictionary<object, TC> _instances = 
            new ConcurrentDictionary<object, TC>();
        public static TC Instance(object key)
        {
            return _instances.GetOrAdd(key, k => new TC());
        }
        public abstract int Demo();
    }
    public class B : A<B>
    {
        public override int Demo() { return 1; }
    }
    public class C : A<C>
    {
        public override int Demo() { return 2; }
    }
