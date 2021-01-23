    public class Bar {
         private Bar() { }
         private static readonly Bar _instance = new Bar();
         public static Bar GetInstance() { return _bar; }
    }
    public class Baz {
        private string _msg;
        private Baz(string msg) { // Not accessible publicly
            _msg = msg;
        }
        // These two are accessible publicly, and both call
        // the private constructor
        public Baz(int i) : this(i + " is an integer") { }
        public Baz(decimal d) : this(d + " is a decimal") { }
    }
    public class Foo {
        private Foo() { // Not accessible publicly
        }
        public static Foo CreateFoo() {
            // Do some stuff here that you can't normally do in a constructor.
            return new Foo();
        }
    }
