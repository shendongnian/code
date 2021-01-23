    static class TestClass
    {
        public static Logger logger = LogManager.GetCurrentClassLogger();  
    }
    class Program
    {            
        static void Main(string[] args)
        {
            var logger = TestClass.logger;
            Console.WriteLine("Press any key");
            Console.ReadLine();
        }
    }
