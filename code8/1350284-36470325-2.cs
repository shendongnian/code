    public interface IMyInterface { }
    public class A : IMyInterface { }
    public class B : IMyInterface { }
    // Covariant interface
    public interface IMyClass<out T> { }
    // Inherit IMyClass
    public class MyClass<T> : IMyClass<T> where T : IMyInterface 
    { 
        public List<T> list = new List<T>(); 
    }
    public class AnotherClass
    {
        // Note the list using IMyClass instead of the concrete MyClass type
        // The covariant interface type would allow any IMyInterface conversion
        public List<IMyClass<IMyInterface>> list = new List<IMyClass<IMyInterface>>();
        public AnotherClass()
        {
            this.list.Add(new MyClass<A>());
            this.list.Add(new MyClass<B>());
        }
    }
