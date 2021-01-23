    interface IFoo { }
    interface IBar { }
    class Foo : IFoo, IBar  { }
    container.RegisterType<IFoo, Foo>();
    container.RegisterType<IBar, Foo>(new InjectionFactory(c => c.Resolve<IFoo>()));
    var foo = container.Resolve<IFoo>();
