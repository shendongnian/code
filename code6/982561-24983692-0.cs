    public interface IFooable
    {
        Foo { get; }
    }
    
    public class ContainingClass 
    {
        private class NestedClass : IFooable
        {
            public int Foo { get; set; }
        }
    
        public IFooable CreateFooable()
        {
            return new NestedClass();
        }
    
        void SomeMethod() {
            NestedClass nc = new NestedClass();
            nc.Foo = 42;                        // <== Allow it here, in the containing class
        }
    }
    
    public class Unrelated 
    {
        void OtherMethod() 
        {
            IFooable nc = ContainingClass.CreateFooable();
            nc.Foo = 42;                        // Now it's an error :P
        }
    }
