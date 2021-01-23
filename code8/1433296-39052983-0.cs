    class Program
    {
        public const int N = 1000000;
        private static object _l = new object();
        private static int _i = 0;
        private static int _j = 0;
        static void Main(string[] args)
        {
            ThreadStart ts = DoWork;
            Thread t = new Thread(ts);
            t.Start();
            for (int x = 0; x < N; x++)
            {
                lock (_l)
                {
                    // j-thread has run?
                    if (_j > 0)
                    {
                        // print and reset j
                        Console.Write("j{0} ", _j);
                        _j = 0;
                    }
                    _i++;
                }
            }
            t.Join();
            // print remaining cycles
            // one of the threads will have run after the other has finished and
            // hence not been printed and reset.
            if (_i > 0)
                Console.Write("i{0} ", _i);
            if (_j > 0)
                Console.Write("j{0} ", _j);
            Console.ReadKey();
        }
        private static void DoWork()
        {
            for (int x = 0; x < N; x++)
            {
                lock (_l)
                {
                    // i-thread has run?
                    if (_i > 0)
                    {
                        // print and reset i
                        Console.Write("i{0} ", _i);
                        _i = 0;
                    }
                    _j++;
                }
            }
        }
    }
