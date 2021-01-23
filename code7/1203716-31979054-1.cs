    class Program
    {
        static void Main(string[] args)
        {
            TestObject tObject = new TestObject();
            Console.WriteLine("TestObject ID: " + tObject.ID);
            Console.WriteLine("TestObject TestObjectCollection ID: " + tObject.TestObjects.ID);
            Console.WriteLine("TestObject TestObjectCollection Parent ID: " + tObject.TestObjects.Parent.ID);
            Console.WriteLine("Press any key...");
            Console.ReadKey(true);
        }
    }
