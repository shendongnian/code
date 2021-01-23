    using System;
    using System.Diagnostics;
    
    static class Program
    {
        static void Main(string[] args)
        {
    
            byte[] results = new byte[6 * 5245786];
            byte[] current = new byte[6];
            int offset = 0;
            var watch = Stopwatch.StartNew();
            Populate(results, ref offset, current, 0);
            watch.Stop();
            Console.WriteLine("Time to generate: {0}ms", watch.ElapsedMilliseconds);
            Console.WriteLine("Data size: {0}MiB",
                (results.Length * sizeof(byte)) / (1024 * 1024));
            Console.WriteLine("All generated; press any key to show them");
            Console.ReadKey();
            for (int i = 0; i < 5245786; i++)
            {
                Console.WriteLine(Format(results, i));
            }
        }
        static string Format(byte[] results, int index)
        {
            int offset = 6 * index;
            return results[offset++] + "," + results[offset++] + "," +
               results[offset++] + "," + results[offset++] + "," +
               results[offset++] + "," + results[offset++];
        }
    
        static void Populate(byte[] results, ref int offset, byte[] current, int level)
        {
            // pick a new candidate; note since we're doing C not P, assume ascending order
            int last = level == 0 ? 0 : current[level - 1];
            for (byte i = (byte)(last + 1); i <= 42; i++)
            {
                current[level] = i;
                if (level == 5)
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
