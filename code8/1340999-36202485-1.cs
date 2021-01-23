    public class MyType
    {
        public IHandler Handler { get;} // notice: no setter
        public MyType() { }
        public MyType(IHandler handler)
        {
            Handler = handler;
        }
    }
