    unityContainer.RegisterType(typeof(IFoo<>), typeof(Foo<>));
    public interface IFooFactory
    {
        IFoo<T> Create<T>();
    }
