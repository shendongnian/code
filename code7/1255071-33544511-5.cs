        static void Main()
        {
            List<long> resultsFirst = new List<long>();
            List<long> resultsIndex = new List<long>();
            Stopwatch s = new Stopwatch();
            for (int z = 0; z < 100; z++)
            {
                List<int>[] lists = new List<int>[10000];
                int temp = 0;
                for (int i = 0; i < lists.Length; i++)
                    lists[i] = new List<int>() { 4, 6 };                
                s.Restart();
                for (int i = 0; i < lists.Length; i++)
                    temp = lists[i].First();
                s.Stop();
                resultsFirst.Add(s.ElapsedTicks);
                s.Restart();
                for (int i = 0; i < lists.Length; i++)
                    temp = lists[i][0];
                s.Stop();
                resultsIndex.Add(s.ElapsedTicks);
            }
            Console.WriteLine("LINQ First()  :   " + resultsFirst.Average());
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("By index      :   " + resultsIndex.Average());
            Console.ReadKey();
        }
