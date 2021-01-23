    public void SingleThreadProcessingLoopAsALongRunningTask(object state)
    {
    	var token = (CancellationToken)state;
    	var buffer = new List<Foo>(TRANSACTION_LIMIT);
    	while (!token.IsCancellationRequested)
    	{
    		Foo item;
    		if (!this._allFoos.TryTake(out item))
    		{
    			if (buffer.Count == 0) continue;
    		}
    		else
    		{
    			buffer.Add(item);
    			if (buffer.Count < TRANSACTION_LIMIT) continue;
    		}
    		using (var ctx = new MyEntityFrameworkContext())
    		{
    			ctx.BulkInsert(buffer);
    		}
    		buffer.Clear();
    	}
    }
