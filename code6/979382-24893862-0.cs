    public class Program
    {
        static void Main(string[] args)
        {
            new Child().Foo(); //will display "Child"
        }
    }
    class Parent
    {
        public virtual void Foo()
        {
            StackFrame frame = new StackFrame(1);
            var method = frame.GetMethod();
            Console.WriteLine(method.DeclaringType.FullName);
        }
    }
    class Child : Parent
    {
        public override void Foo()
        {
            base.Foo();
        }
    }
