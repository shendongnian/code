    public interface IMyInterface { }
    public class A : IMyInterface { }
    public class B : IMyInterface { }
    public interface IMyClass<out T> { }
    public class MyClass<T> : IMyClass<T> where T : IMyInterface { public List<T> list = new List<T>(); }
    public class AnotherClass
    {
        public List<IMyClass<IMyInterface>> list = new List<IMyClass<IMyInterface>>();
        public AnotherClass()
        {
            this.list.Add(new MyClass<A>());
            this.list.Add(new MyClass<B>());
        }
    }
