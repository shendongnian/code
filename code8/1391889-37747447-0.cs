            var a = new List<int>();
            for(int i = 10000000; i > 0; i --)
                a.Add(i);
            DateTime start = DateTime.Now;
            a.AsParallel().OrderBy(x=>x).ForAll(x => x = x ++);
            var timeSpent = DateTime.Now - start;
            start = DateTime.Now;
            a.OrderBy(x => x).AsParallel().ForAll(x => x = x++);
            var timeSpent2 = DateTime.Now - start;
            Console.WriteLine(string.Format("1 - {0} 2 - {1}", timeSpent, timeSpent2));
            Console.ReadLine();
