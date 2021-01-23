    var consumer1 = new BlockingCollection(maxCapacity: 1);
    var consumer2 = new BlockingCollection(maxCapacity: 1);
    var task1 = Task.Run(() => M1(consumer1.GetConsumingEnumerable()));
    var task2 = Task.Run(() => M2(consumer2.GetConsumingEnumerable()));
    
    foreach (var item in sourceCollection) {
     consumer1.Add(item);
     consumer2.Add(item);
    }
    
    consumer1.CompleteAdding();
    consumer2.CompleteAdding();
    
    Task.WaitAll(task1, task2);
