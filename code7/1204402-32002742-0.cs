    public TaskAwaiter<Tuple<YourObject, IEnumerable<ODataEntry>>> GetAwaiter()
    {
      return 
        queryResults
        .ContinueWith(t => Tuple.Create(this, t.Result))
        .GetAwaiter();
    }
