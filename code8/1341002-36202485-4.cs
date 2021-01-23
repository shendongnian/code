    abstract class Handler
    {
       MyType _type;
       public Handler(MyType type)
       {
           Type = type;
       }
        public abstract void DoSomething(string s) { ... }
    }
    class ConcreteHandler: Handler
    {
        public override void DoSomething(string s) { ... }
    }
    interface IHandlerFactory
    {
        Handler CreateHandler(MyType type);
    }
    class ConcreteFactory: IHandlerFactory
    {
        public Handler CreateHandler(MyType type) => new ConcreteHandler(type);
    }
