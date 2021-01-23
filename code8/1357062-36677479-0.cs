       class Program
    {
        private static System.Threading.Timer _timer = new Timer(_ => Console.WriteLine("Hi"), 
            null, 1000, 1000);
        static void Main(string[] args)
        {
            Console.ReadLine();
        }
    }
