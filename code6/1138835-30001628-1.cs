    public class FooFactory
    {
        public FooFactory(IComponentContext componentContext)
        {
            this._componentContext = componentContext;
            this._instances = new Dictionary<Int32, Foo>();
            this._lock = new Object();
        }
        private readonly IComponentContext _componentContext;
        private readonly Dictionary<Int32, Foo> _instances;
        private readonly Object _lock;
        public Foo GetInstance(Int32 a)
        {
            Foo parameterizedFoo;
            if (!this._instances.TryGetValue(a, out parameterizedFoo))
            {
                lock (this._lock)
                {
                    if (!this._instances.TryGetValue(a, out parameterizedFoo))
                    {
                        Parameter aParameter = new TypedParameter(typeof(Int32), a);
                        parameterizedFoo = this._componentContext
                                               .Resolve<Foo>(aParameter);
                        this._instances[a] = parameterizedFoo;
                    }
                }
            }
            return parameterizedFoo;
        }
    }
