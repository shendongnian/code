        public static void PrintDone()
        {
            Console.WriteLine("Done");
        }
        public static void Print(int i)
        {
            Console.WriteLine(i);
            Thread.Sleep(10);
        }
        static void Main(string[] args)
        {
            List<Thread> threads = new List<Thread>();
            for(int i = 0; i < 10; ++i)
            {
                int numCopy = i;
                Thread th = new Thread(() => Print(numCopy));
                threads.Add(th);
            }
            for (int i = 0; i < 10; ++i)
            {
                threads[i].Start();
                threads[i].Join();
            }
            PrintDone();
            Console.ReadLine();
            
        }
