    public IEnumerable<Thing> GetThings(System.IO.Stream s)
    {
        var parser = new Parser(s);
        var waitable = new AutoResetEvent(false);
        Thing item = null;
        parser.OnParsedData += (Thing thing) => 
        {
            item = thing;
            waitable.Set();
        };
        IAsyncResult result = parser.BeginProcessing();
        while (!result.IsCompleted)
        {
            waitable.WaitOne();
            yield return item;            
        }
    }
