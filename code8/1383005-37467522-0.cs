        private void DoIt()
        {
            const int numReps = 1000000000;
            PackStats stats1 = new PackStats();
            PackStats stats2 = new PackStats();
            stats1.a = 55;
            stats1.b = 3;
            stats1.c = stats1.a + stats1.b;
            for (var i = 0; i < 2; ++i)
            {
                var sw1 = Stopwatch.StartNew();
                for (var j = 0; j < numReps; ++j)
                {
                    stats2 = stats1;
                }
                sw1.Stop();
                Console.WriteLine("Copy struct = {0:N0} ms", sw1.ElapsedMilliseconds);
                sw1.Restart();
                for (var j = 0; j < numReps; ++j)
                {
                    stats2.a = stats1.a;
                    stats2.b = stats1.b;
                    stats2.c = stats1.c;
                }
                sw1.Stop();
                Console.WriteLine("Copy fields = {0:N0} ms", sw1.ElapsedMilliseconds);
            }
        }
