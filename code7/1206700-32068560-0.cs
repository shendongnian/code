    class Program
    {
        static void Main(string[] args)
        { 
            for(int i = 0; i >= -10; i -= 2)
            {
                Console.Write("{0,2}", i);
                System.Threading.Thread.Sleep(1000);
            }
            Console.WriteLine("Countdown End");
        }
    }
