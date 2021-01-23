    using System;
    static class Program
    {
        static void Main(string[] args)
        {
            int[] results = new int[6 * 5245786];
            int[] current = new int[6];
            int offset = 0;
            var watch = Stopwatch.StartNew();
            Populate(results, ref offset, current, 0);
            watch.Stop();
            Console.WriteLine("Time to generate: {0}ms", watch.ElapsedMilliseconds);
            Console.WriteLine("Data size: {0}MiB", (results.Length * sizeof(int)) / (1024 * 1024));
            Console.WriteLine("All generated; press any key to show them");
            Console.ReadKey();
            for(int i = 0; i < 5245786; i++)
            {
                Console.WriteLine(Format(results, i));
            }
        }
        static string Format(int[] results, int index)
        {
            int offset = 6 * index;
            return results[offset++] + "," + results[offset++] + "," + results[offset++] + "," + results[offset++] + "," + results[offset++] + "," + results[offset++];
        }
        static void Populate(int[] results, ref int offset, int[] current, int level)
        {
            // pick a new candidate; note since we're doing C not P, assume ascending order
            int last = level == 0 ? 0 : current[level - 1];
            for(int i = last + 1; i <= 42; i++)
            {
                current[level] = i;
                if(level == 5)
                {
                    // write the results
                    Array.Copy(current, 0, results, offset, 6);
                    offset += 6;
                }
                else
                {
                    // dive down
                    Populate(results, ref offset, current, level + 1);
                }                
            }
        }
    }
