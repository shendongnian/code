    while (true)
    {    
        // we want to run it again in 0.5 seconds.
        DateTime start = DateTime.UtcNow.AddSeconds(0.5); 
        
        Thread[] threads = new Thread[models.Count];
        for (int i=0; i<models.Count; ++i)
        {
        	threads[i] = new Thread(()=> SaveServerInfo(models[i]));
        }
        
        for (int i=0; i<models.Count; ++i)
        {
        	threads[i].Join();
        }
        
        DateTime current = DateTime.UtcNow;
        if (current < start)
        {
        	Thread.Sleep(start.Subtract(current));
        }
        
    }
