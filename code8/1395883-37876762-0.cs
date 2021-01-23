    public class FooFactory : IFooFactory
    {
        public delegate IFoo FooBuilder(String key);
        public FooFactory(FooBuilder fooBuilder)
        {
            this._fooBuilder = fooBuilder;
            this._foos = new ConcurrentDictionary<String, IFoo>();
        }
        private readonly FooBuilder _fooBuilder;
        private readonly ConcurrentDictionary<String, IFoo> _foos;
        public IFoo Get(String key)
        {
            IFoo foo = this._foos.GetOrAdd(key, k => this._fooBuilder(k));
            return foo;
        }
    }
