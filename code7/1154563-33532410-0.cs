    public class FooBase
    {
        private readonly object _obj;
        protected FooBase(object obj)
        {
            Contract.Requires(obj != null);
            _obj = obj;
        }
    }
    public class Foo : FooBase
    {
        public Foo(object obj) : base(obj)
        {
            Contract.Requires(obj != null);
        }
    }
