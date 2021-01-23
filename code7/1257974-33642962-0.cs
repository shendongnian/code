                Stopwatch stopwatch = Stopwatch.StartNew(); 
                int[] i = new[] { 1, 2, 3, 4, 5, 6, 7 };
    
                for (int j= 0; 1000000 > j; j++)
                {
                    int pos = Array.IndexOf(i, 5);
                    if (pos > -1)
                    { }
                }
               
                stopwatch.Stop();
                Console.WriteLine(stopwatch.ElapsedMilliseconds);
    
    
                Stopwatch stopwatch2 = Stopwatch.StartNew();
                for (int j = 0; 1000000 > j; j++)
                {
                    bool pos = i.Contains(5);
                    if (pos)
                    { }
                }
                stopwatch2.Stop();
                Console.WriteLine(stopwatch2.ElapsedMilliseconds);
