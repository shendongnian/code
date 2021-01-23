    public interface IFooFactory
    {
        [ResolveTo(typeof(Foo<>))]
        IFoo Create<T>();
    }
