    public Task<int?> ValueOrNull( )
    {
        return Task.WhenAny(
            SomeAsyncMethod(),
            DelayResult(default(int?), TimeSpan.FromSeconds(5))
        );
    }
    public async Task<T> DelayResult<T>(T result, TimeSpan delay)
    {
        await Task.Delay(delay);
        return result;
    }
