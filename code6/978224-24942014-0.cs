        static void Main(string[] args)
        {
            var q = new Queue<long>();
            var hs = new []
            {
                new HashSet<long>(),
                new HashSet<long>(),
                new HashSet<long>(),
                new HashSet<long>()
            };
            for (long i = 0; i < 25000000; ++i)
            {
                q.Enqueue(i);
                if (i < 12500000)
                {
                    foreach (var h in hs)
                    {
                        h.Add(i);
                    }
                }
            }
            Console.WriteLine("Press [enter] to exit");
            Console.ReadLine();
        }
