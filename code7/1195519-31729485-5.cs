    public class SomeClass
    {
        public readonly Action someMethod;
        public SomeClass(Action someMethod) { this.someMethod = someMethod; }
    }
    public class Program
    {
        static void Main()
        {
            var someClassInstance =
            new SomeClass
            (
                someMethod:
                ()=>
                {
                    // do what you want.
                }
            );
            someClassInstance.someMethod();
        }
    }
