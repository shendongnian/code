    public class MyType
    {
        public IHandler Handler { get; }
        public MyType() { }
        public MyType(IHandlerFactory factory)
        {
            // create instance via factory
            Handler = factory.CreateHandler(this);
        }
    }
