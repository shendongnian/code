    [ComVisible(true)]
    public interface IFoo {
       //...
    }
    
    class Foo : IFoo {
       public Foo(int a, string b) { ... }
       //...
    }
    
    [ComVisible(true)]
    public class FooFactory {
        public IFoo CreateInstance(int a, string b) {
            return new Foo(a, b);
        }
    }
