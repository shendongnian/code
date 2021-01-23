    public async Task RunInParallel(IEnumerable<TWhatEver> mbisItems)
    {
        //mbisItems == your parameter that you want to pass to GetAllRouterInterfaces
        //degree of cucurrency
        var concurrentTasks = 3;
        //Parallel.Foreach does internally something like this:
        await Task.WhenAll(
            from partition in Partitioner.Create(mbisItems).GetPartitions(concurrentTasks)
            select Task.Run(async delegate
            {
                using (partition)
                    while (partition.MoveNext())
                    {
                        var currentMbis = partition.Current;
                        var yourResult = await GetAllRouterInterfaces(currentMbis,3);
                    }
            }
           ));
    }
