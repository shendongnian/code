    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading;
    
    class AsParallelTest
    {
        static void Main()
        {
            var query = Enumerable.Range(0, 1000)
                                  .Select(ProjectionExample)
                                  .Where(x => x > 10)
                                  .AsParallel();
            Stopwatch stopWatch = Stopwatch.StartNew();
            int count = query.Count();
            stopWatch.Stop();
            Console.WriteLine("Count: {0} in {1}ms", count,
                              stopWatch.ElapsedMilliseconds);
            query = Enumerable.Range(0, 1000)
                              .AsParallel()
                              .Select(ProjectionExample)
                              .Where(x => x > 10);
            stopWatch = Stopwatch.StartNew();
            count = query.Count();
            stopWatch.Stop();
            Console.WriteLine("Count: {0} in {1}ms", count,
                           stopWatch.ElapsedMilliseconds);
       }
       static int ProjectionExample(int arg)
       {
           Thread.Sleep(10);
           return arg;
       }
    }
