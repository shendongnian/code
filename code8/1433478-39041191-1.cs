    private void DealWithNotification(CancellationToken token)
    {
        if(token.IsCancellationRequested) return;
        var foo = "omgwtflol" + bar;
        if(token.IsCancellationRequested) return;
        Thread.Sleep(2);
        if(token.IsCancellationRequested) return;
        var reallyEveryTime = File.ReadAllBytes(foo);
        if(token.IsCancellationRequested) return;
        foreach(var b in reallyEveryTime)
        {
            if(token.IsCancellationRequested) return;
            InnerProcess(token); 
        }
        // etc etc etc you get the idea
    }
