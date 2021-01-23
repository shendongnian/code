    static async void tester()
    {
        TaskFunctions T = new TaskFunctions();
        List<string> p = new List<string>() { "111" };
        List<Task> CocurrentTasks = new List<Task>();
        foreach (string s in p)
        {
            CocurrentTasks.Add(CallConcurrentTasks(T, s));
        }
        while (CocurrentTasks.Count > 0)
        {
            var nextTask = await Task.WhenAny(CocurrentTasks);            
            CocurrentTasks.Remove(nextTask);
        }
    }
	
	static async Task CallConcurrentTasks(TaskFunctions t, string arg)
	{
		do
		{
			if (await t.FirstLevel(arg))
			{
				if (!await T.SecondLevel("GG"))
				{
					return;
				}
			}
		}
		while (true);	//you should probably make some additional end condition here?
	}
