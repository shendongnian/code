    List<int> ints = new List<int> {3, 2, 1};
    
    ints.ForEachAsync(async i =>
            {
                Console.WriteLine("Task async {0} starting", i);
                await Task.Delay(i*1000);
                Console.WriteLine("Task async {0} done", i);
            }
        ).Wait();
    
    ints.ParallelForEach(async i =>
            {
                Console.WriteLine("Task parallel {0} starting", i);
                await Task.Delay(i*1000);
                Console.WriteLine("Task parallel {0} done", i);
            });
