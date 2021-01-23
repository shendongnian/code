    class Program
    {
        static void Main(string[] args)
        {
            testDynamic(new hello());
            testDynamic(new hello2());
            Console.ReadLine();
        }
        static void testDynamic(hello h)
        {
            h.writeDynamic();
        }
    }
