    class Program
    {
        interface ISomeInterface
        {
            string SomeProperty { get; }
        }
        static ISomeInterface CreateSomeClass()
        {
            return new SomeClass();
        }
        class SomeClass : ISomeInterface
        {
            public string SomeProperty
            {
                get
                {
                    throw new NotImplementedException();
                }
                set
                {
                    throw new NotImplementedException();
                }
            }
        }
        static void Main(string[] args)
        {
            ISomeInterface someInterface = CreateSomeClass();
            someInterface.SomeProperty = "test"; //Wont compile
        }
    }
