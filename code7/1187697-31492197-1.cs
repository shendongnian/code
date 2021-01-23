    class Program
    {
        static BlockingCollection<int> mQ = new BlockingCollection<int>();
        static void Main(string[] args)
        {
            Thread rxThread = new Thread(rxThreadFunc);
            rxThread.Priority = ThreadPriority.Highest;//this causes problem
            rxThread.Start();
            Thread procThread = new Thread(dataProc);
            procThread.Start();
            Console.ReadLine();
        }
        static public void rxThreadFunc()
        {
            for (int i = 0; i < 10; i++)
            {
                mQ.Add(i);
            }
        }
        static public void dataProc()
        {
            foreach (int outData in mQ.GetConsumingEnumerable())
            {
                Console.WriteLine(outData);
            }
        }
    }
