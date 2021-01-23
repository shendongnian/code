    while (true)
    {
	    ThreadEvent.WaitOne(waitingTime, false);
	    lock (SyncVar)
	    {
	    	collection = new BlockingCollection<string>(4);
		    DoWork dc = new DoWork();
		    Task consumer = Task.Run(() =>
		    {
		    	while (!collection.IsCompleted)
		    	{
			    	string data = "";
			    	try
			    	{
				    	if (collection.Count > 0)
					    	data = collection.Take();
				    }
				    catch (InvalidOperationException e)
				    {
					    Console.WriteLine(e.Message);
				    }
				    if (data != "")
				    {
					    bool result = dc.DoConsume(data);
				    }
			    }
		    });
		    Task producer = Task.Run(() =>
		     {
			     if (list.Count > 0)
				     Console.WriteLine("Block begin");
			     foreach (var item in list)
			     {
				     collection.Add(item);
			     }
			     list.Clear();
			     collection.CompleteAdding();
		     });
		    Task endTask = consumer.ContinueWith(i => Console.WriteLine("Block end"));
		    Task.WaitAll(producer, consumer, endTask);
		    if (ThreadState != State.Running) break;
	    }
