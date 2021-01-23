    public async Task<Tuple<int, T>> TimeFunc<T>(
            Func<T> target,
            int timeoutMilliseconds)
    {
        var timer = Stopwatch.StartNew();
        var results = await Task.WhenAny(new[]
            {
                Task.Run(() => target()),
                Task.Delay(timeoutMilliseconds)
            });
        timer.Stop();
        if (results[1].RanToCompletion)
        {
            throw new TimeoutException();
        }
        return Tuple.Create(timer.ElapsedMilliseconds, results[0].Result);
    }
  
