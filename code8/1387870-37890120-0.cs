    private static async void TimerCallback(object state)
    {
            if (Interlocked.CompareExchange(ref currentlyRunningTasksCount, 1, 0) != 0)
            {
                return;
            }
    
            var tasksRead = Enumerable.Range(3, 35).Select(i => ReadSensorsAsync(i));
            var finshedTasks = await Task.WhenAll(tasksRead);
            var tasksRecord = finshedTasks.Where(x => x != null).Select(x => RecordReadingAsync(x));
            await Task.WhenAll(tasksRecord);
    
            Interlocked.Decrement(ref currentlyRunningTasksCount);
    }
