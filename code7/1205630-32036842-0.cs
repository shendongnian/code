    private List<Task<ResponseBase>> _actionsDict;
    
    public ExecutingScheduler()
    {
    	_actionsDict = new List<Task<ResponseBase>>();
    	Task.Factory.StartNew(ExecuteNextTask);
    }
    
    private void ExecuteNextTask()
    {
    	while (_actionsDict.Count > 0)
    	{
    		// Get first while removing it
    		var next = _actionsDict[0];
    		_actionsDict.RemoveAt(0);
    
    		next.Start();
    		next.Wait();
    		
    		Task.Delay(2000);
    	}
    }
    
    public async Task<ResponseBase> StartStreamAsync(ClassA classA, ClassB classB)
    {
    	var task = new Task<ResponseBase>(() => StartStream(classA, classB));
    	
    	_actionsDict.Add(task);
    
    	return task.Result;
    }
    
    public async Task<ResponseBase> PrepareStreamAsync(ClassA classA, ClassB classB)
    {
    	var task = new Task<ResponseBase>(() => PrepareStream(classA, classB))
        _actionsDict.Add(task);    
    	return task.Result;
    }
