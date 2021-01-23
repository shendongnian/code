    public interface IFooable
    {
        int Foo { get; }
    }
    public class ContainingClass 
    {
        private class NestedClass : IFooable
        {
            public int Foo { get; set; }
        }
        public static IFooable CreateFooable()
        {
            NestedClass nc = new NestedClass();
            nc.Foo = 42;
            return nc;
        }
        void SomeMethod() {
            NestedClass nc = new NestedClass();
            nc.Foo = 67;                        // <== Allow it here, in the containing class
        }
    }
    public class Unrelated 
    {
        public void OtherMethod() 
        {
            IFooable nc = ContainingClass.CreateFooable();
            Console.WriteLine(nc.Foo);
            nc.Foo = 42;                        // Now it's an error :P
        }
    }
