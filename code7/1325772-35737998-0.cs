    public class A : IMy
    {
        public virtual void F()
        {
            Console.WriteLine("A");
        }
    }
    public class B : A
    {
        public override void F()
        {
            Console.WriteLine("B");
        }
    }
