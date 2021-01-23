    container.RegisterType<IMyInterface, Foo>();
    container.RegisterType<IMyInterface, Bar>("bar");
    
    var foo = container.TryResolve<IMyInterface>("non-existing");
    // foo will be Foo
    var bar = container.TryResolve<IMyInterface>("bar");
    // bar will be Bar.
    
    public interface IMyInterface { }
    public class Foo : IMyInterface { }
    public class Bar : IMyInterface { }
