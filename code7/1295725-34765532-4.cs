    private class ProcessItem
    {
       //define each task data
    }
    
    private static readonly ConcurrentQueue<ProcessItem> queue 
                                          = new ConcurrentQueue<ProcessItem>();
    
    private static Thread worker = new Thread(() =>
    {
        while (true) // infinite
        {
            ProcessItem item;
            if (!queue.TryDequeue(out item))
            { //no availble items, wait for an item
               Monitor.Enter(queue); Monitor.Wait(queue); Monitor.Exit(queue);
              continue; //I have been notified, repeat check
            }
            //now process item
        }
    });
    static YourClass()
    {
         worker.Start(); //start the worker at class first-load
    }
