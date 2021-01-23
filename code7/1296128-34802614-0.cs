    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 20000000; ++i)
            {
                string s = i.ToString("X");
                string.Intern(s);
            }
            GC.Collect(3, GCCollectionMode.Forced, true);
            long t1 = Stopwatch.GetTimestamp();
            GC.Collect(3, GCCollectionMode.Forced, true);
            long t2 = Stopwatch.GetTimestamp();
            Console.WriteLine((double)(t2 - t1) / Stopwatch.Frequency);
        }
    }
