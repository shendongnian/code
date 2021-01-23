    public class Foo
    {
        public void Bar1<T>() where T : class {}
        public void Bar2<T>() where T : class
        {
            Bar1<T>(); // same constraints, it's OK
        } 
    
        public void Bar3<T>() where T : class, ISomeInterface
        {
            Bar1<T>(); // more constraints, it's OK too
        }
    
        public void Bar4<T>()
        {
            Bar1<T>(); // less constraints, error
        }
    }
