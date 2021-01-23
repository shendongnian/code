     class Program
    {
        static List<int> list;
        static ManualResetEventSlim mres = new ManualResetEventSlim(false);
        static void Main(string[] args)
        {
            list = new List<int>();
            for (int i = 0; i < 10000000; i++)
            {
                list.Add(i);
                if (i == 1000)
                {
                    Thread t = new Thread(new ThreadStart(WorkThreadFunction));
                    t.Start();
                    mres.Wait();
                }
            }
        }
        static void WorkThreadFunction()
        {
            List<int> tmp = list.ToList();
            Console.WriteLine(list.Count);
            mres.Set();
        }
    }
