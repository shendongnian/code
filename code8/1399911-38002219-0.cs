    abstract class Base
    {
        public abstract void DoSomethingWithArg(string arg);
    }
    class ClassOne : Base
    {
        public override void DoSomethingWithArg(string arg)
        {
            Console.WriteLine($"Class One says {arg}");
        }
    }
    class ClassTwo : Base
    {
        public override void DoSomethingWithArg(string arg)
        {
            Console.WriteLine($"Class Two says {arg}");
        }
    }
