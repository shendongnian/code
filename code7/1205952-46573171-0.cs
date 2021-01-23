    public static async Task RunMyThrottledTasks()
    {
        var myArgsSource = new[] { 1, 2, 3, 4 };
        await myArgsSource
            .Select(a => (Func<Task<object>>)(() => DoSomething(a)))
            .Throttle(10);
    }
    
    public static async Task<object> DoSomething(int arg)
    {
        // Await some async calls that need arg..
        // ..then return result async Task..
        return new object();
    }
    
    public static async Task<IEnumerable<T>> Throttle<T>(IEnumerable<Func<Task<T>>> toRun, int throttleTo)
    {
        var running = new List<Task<T>>(throttleTo);
        var completed = new List<Task<T>>(toRun.Count());
        foreach(var taskToRun in toRun)
        {
            running.Add(taskToRun());
            if(running.Count == throttleTo)
            {
                var comTask = await Task.WhenAny(running);
                running.Remove(comTask);
                completed.Add(comTask);
            }
        }
        return completed.Select(t => t.Result);
    }
    
    public static async Task Throttle(this IEnumerable<Func<Task>> toRun, int throttleTo)
    {
        var running = new List<Task>(throttleTo);
        foreach(var taskToRun in toRun)
        {
            running.Add(taskToRun());
            if(running.Count == throttleTo)
            {
                var comTask = await Task.WhenAny(running);
                running.Remove(comTask);
            }
        }
    }
