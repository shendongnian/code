    public class Foo {
        private readonly IMyHelperFactory _factory;
        public Foo(IMyHelperFactory factory) {
            _factory = factory;
        }
        public void MethodThatCreatesMyHelper() {
            var instance = _factory.Create();
            // you now have a valid instance of `MyHelper`
        }
    }
