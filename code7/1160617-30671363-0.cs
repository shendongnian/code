    public class LazyFooProxy : IFoo
    {
        private readonly Lazy<IFoo> foo;
        public LazyFooProxy(Lazy<IFoo> foo) {
            this.foo = foo;
        }
        public bool IsCreated {
            get { return this.foo.IsValueCreated; }
        }
        void IFoo.Method() {
            this.foo.Value.Method();
        }
    }
