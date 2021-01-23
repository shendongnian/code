    public class Super
    {
        public virtual void display()
        {
            Console.WriteLine("super/base class");
        }
    }
    public class Sub : Super
    {
        public override void display()
        {
            Console.WriteLine("Child class");
        }
    }
