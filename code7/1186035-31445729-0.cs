    class Program
    {
        static List<int> list;
        static object SyncRoot = new object();
        static void Main(string[] args)
        {
            list = new List<int>();
            for (int i = 0; i < 1000000; i++)
            {
                lock (SyncRoot) //Lock before modification
                {
                    list.Add(i);
                }
                if (i == 1000)
                {
                    Thread t = new Thread(new ThreadStart(WorkThreadFunction));
                    t.Start();
                }
            }
            Console.ReadLine();
        }
        static void WorkThreadFunction()
        {
            lock (SyncRoot)
            {
                List<int> tmp = list.ToList();  //Exception here!
                Console.WriteLine(list.Count);
            }
        }
    }
