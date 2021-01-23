    // the provider method
    // _queue = new BlockingCollection<string>()
    public void AddLines(IEnumerable<string> lines)
    {
       foreach (var line in lines)
       {
         _queue.Add(line);
       }
    }
