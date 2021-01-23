    // the provider method
    public void AddLines(IEnumerable<string> lines)
    {
       foreach (var line in lines)
       {
         _queue.Enqueue(line);
         // releae per item added, allows for multiple  consumers
         _sema.Release(); 
       }
    }
