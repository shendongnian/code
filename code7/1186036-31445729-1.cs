    class Program
    {
        static List<int> list;
        static void Main(string[] args)
        {
            list = new List<int>();
            for (int i = 0; i < 1000000; i++)
            {
                lock (list) //Lock before modification
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
            lock (list)
            {
                List<int> tmp = list.ToList();  //Exception here!
                Console.WriteLine(list.Count);
            }
        }
    }
