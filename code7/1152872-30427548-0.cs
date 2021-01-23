    var tokenSource = new CancellationTokenSource();
    var token = tokenSource.Token;
    Task.Factory.StartNew(x =>
    {
        var token = x as CancellationToken;
        for(var item in ReallyBigCollection){
            Process(item, token);
            if(token.IsCancellationRequested)
                return;
        }
    }, token, token);
