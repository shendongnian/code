    public class C<T>
    {
        public C(T t)
        {
            // ...
        }
    }
    public static class Factory
    {
        public static C<T> Create<T>(T t)
        {
            return new C<T>(t);
        }
    }
    public class Thing
    {
        void Foo()
        {
            var x = new { y = "z" };
            //var thing = new C(x); - doesn't work, you need to specify the generic parameter
            var thing = Factory.Create(x); // T is inferred here
        }
    }
