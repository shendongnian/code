    const int taskCount = 20;
    var tasks = new List<Task>();
    for (int i = 0; i < taskCount; i++) {
    	int counter = i;
    	var task = Task.Run(() => {
    		Console.WriteLine($"T{counter}: Start.");
    		Thread.Sleep(500);
    		Console.WriteLine($"T{counter}: Complete.");
    	});
    	tasks.Add(task);
    }
    Thread.Sleep(400);
    var continuations = new List<Task>();
    for (int i = 0; i < taskCount; i++) {
    	int counter = i;
    	var continuation = tasks[i].ContinueWith(t => {
    		Console.WriteLine($"C{counter}: Start.");
    		Thread.Sleep(150);
    		Console.WriteLine($"C{counter}: Complete.");
    	});
    	continuations.Add(continuation);
    }
    Task.WaitAll(continuations.ToArray());
