    static void Main(string[] args)
    {
        var tasks = Enumerable.Range(0, 4).Select(taskNumber => Task.Run(async () =>
        {
            Console.WriteLine("Task {0} starting", taskNumber);
            await Task.Delay((taskNumber + 1) * 1000);
            Console.WriteLine("Task {0} stopping", taskNumber);
        })).ToList();
        // Wait for all tasks to complete and do progress report
        var whenAll = WhenAllEx(
            tasks, 
            _ => Console.WriteLine("Still in progress. ({0}/{1} completed)", _.Count(task => task.IsCompleted), tasks.Count()));
        // Usually never wait for asynchronous operations unless your in Main
        whenAll.Wait();
        Console.WriteLine("All tasks finished");
        Console.ReadKey();
    }
    /// <summary>
    /// Takes a collection of tasks and completes the returned task when all tasks have completed. If completion
    /// takes a while a progress lambda is called where all tasks can be observed for their status.
    /// </summary>
    /// <param name="tasks"></param>
    /// <param name="reportProgressAction"></param>
    /// <returns></returns>
    public static async Task WhenAllEx(ICollection<Task> tasks, Action<ICollection<Task>> reportProgressAction)
    {
        var whenAllTask = Task.WhenAll(tasks);
        for (; ; )
        {
            var timer = Task.Delay(250); // you might want to make this configurable
            await Task.WhenAny(whenAllTask, timer);
            if (whenAllTask.IsCompleted)
            {
                return;
            }
            reportProgressAction(tasks);
        }
    }
