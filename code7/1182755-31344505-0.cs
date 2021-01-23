    await Task.Run(async () =>
    {
        _token.Token.ThrowIfCancelltionRequested();
        await Task.Delay(2500, _token.Token);
        _token.Token.ThrowIfCancelltionRequested();
        
        Console.WriteLine(string.Format("IsCancellationRequested={0}", _token.Token.IsCancellationRequested));
        Console.WriteLine("SHOULD NOT HAPPEN");
    }, _token.Token);
