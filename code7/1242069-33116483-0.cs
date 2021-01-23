    interface IExample
    {
        void HelloWorld();
    }
    
    class ExampleClass : IExample
    {
        public void HelloWorld()
        {
            Console.WriteLine("Hello world.");
        }
    }
