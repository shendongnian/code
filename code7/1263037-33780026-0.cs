    var c = t.ContinueWith(tk => 
    {
        _myTimer = new Timer(TestItem, null, 2500, 2500);
        //you can check the type of exception, etc
        //if(tk.Exception is AggregateException) //etc
        var message = tk.Exception.Message;
    }, TaskContinuationOptions.OnlyOnFaulted);
