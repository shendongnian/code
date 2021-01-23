    var source = new CancellationTokenSource();
    var token = source.Token;
    var task = Task.Factory.StartNew(() =>
    {
        // Were we already canceled?
        ct.ThrowIfCancellationRequested();
        var moreToDo = true;
        while (moreToDo)
        {
            // Poll on this property if you have to do 
            // other cleanup before throwing. 
            if (ct.IsCancellationRequested)
            {
                // Clean up here, then...
                ct.ThrowIfCancellationRequested();
            }
        }
    }, token);
