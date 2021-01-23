    Random random = new Random();
    var tasks = new List<Task>();
    for (int i = 0; i < 50; i++)
    {
    	if (random.NextDouble() > .1)
    		tasks.Add(Task.Factory.StartNew(() => { AddLayout(); }));
    	else
    		tasks.Add(Task.Factory.StartNew(() => { ClearLayout(); }));
    }
    var completed = Task.Factory.ContinueWhenAll(tasks.ToArray(), (messagecenterTasks) => { 
    	foreach (var task in messagecenterTasks)
    	{
    		if (task.Status == TaskStatus.Faulted)
    		{
    			D.WriteLine("Faulted:");
    			D.WriteLine($"  {task.Exception.Message}");
    		}
    	}
    }).Wait(1000);
    if (!completed)
    	D.WriteLine("Some tasks did not complete in time allocated");
