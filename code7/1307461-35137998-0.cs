    // add generic handler
    interface IHandler { }
    interface IHandler<T> : IHandler { }
    interface IHandlerFactory {
       IHandler Create(Type t);
    }
    
    Component.For<IHandlerFactory>().AsFactory();
