    class Program
    {
        public static event Action<string> myEvent;
        static void Main(string[] args)
        {
            myEvent += Program_myEvent1;
            myEvent("Cheese");
        }
        private static void Program_myEvent1(string val)
        {
            Console.WriteLine(val);
            Console.ReadKey();
        }
    }
