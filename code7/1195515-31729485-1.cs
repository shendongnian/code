    public class SomeClass
    {
        public Action someMethod { get; set; }
    }
    public class Program
    {
        static void Main()
        {
            var someClassInstance =
            new SomeClass()
            {
                someMethod =
                ()=>
                {
                    // do what you want.
                }
            };
            someClassInstance.someMethod();
        }
    }
