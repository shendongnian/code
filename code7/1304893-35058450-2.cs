    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    namespace Demo
    {
        static class Program
        {
            static Random rng = new Random();
            static void Main()
            {
                // Process files in parallel, with a maximum thread count.
                var opts = new ParallelOptions {MaxDegreeOfParallelism = 8};
                Parallel.ForEach(fileList(), opts, processFile);
            }
            static IEnumerable<string> fileList()
            {
                // Simulate having a list of files.
                var fileList = Enumerable.Range(1, 100000).Select(x => x.ToString()).ToArray();
                // Simulate finishing after a few seconds.
                DateTime endTime = DateTime.Now + TimeSpan.FromSeconds(10);
                int i = 0;
                while (DateTime.Now <= endTime)
                    yield return fileList[i++];
            }
            static void processFile(string file)
            {
                Console.WriteLine("Processing file: " + file);
                // Simulate taking a varying amount of time per file.
                int delay;
                lock (rng)
                {
                    delay = rng.Next(200, 2000);
                }
                Thread.Sleep(delay);
                Console.WriteLine("Processed file: " + file);
            }
        }
    }
