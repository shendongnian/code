    public class A : IMy
    {
        public virtual void F() // <--- Mark as virtual to allow subclasses to override
        {
            Console.WriteLine("A");
        }
    }
    
    public class B : A
    {
        public override void F() // <-- Override the method rather than hiding it
        {
            Console.WriteLine("B");
        }
    }
