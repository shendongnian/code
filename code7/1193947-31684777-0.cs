    public class Parent
    {
        // Declare this as virtual, allowing it to be overridden in
        // derived classes. The implementation will depend on the
        // execution-time type of the object it's called on.
        public virtual void Print()
        {
            Console.WriteLine ("Parent Method");
        }
    }
    
    public class Child : Parent
    {
        // Override Parent.Print, so if Print is called on a reference
        // with compile-time type of Parent, but at execution it
        // refers to a Child, this implementation will be executed.
        public override void Print()
        {
            Console.WriteLine ("Child Method");
        }
    }
