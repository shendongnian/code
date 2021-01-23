    public interface IFoo<T>
    {
        public void FooMethod(T ob)
        {
        }
    }
    class Foo : IFoo<Foo>
    {
    }
