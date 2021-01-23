        var collection = new BlockingCollection<MyTask>();
        Task.Run(async () =>
        {
            while (true)
            {
                var tasks = GrabCurrentListOfTasks();
                foreach (var task in tasks)
                {
                    collection.Add(task);
        
                    await Task.Delay(someShortDelay);
                }
            }
        });
        Parallel.ForEach(collection.GetConsumingPartitioner(), task => DoWorkForTask(task));
