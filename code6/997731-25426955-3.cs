    private static async Task RetryAsync()
    {
        var retryStrategy = new Incremental(5, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(2));
        var retryPolicy = new RetryPolicy(DatabaseDeadlockTransientErrorDetectionStrategy.Instance, retryStrategy);
        try
        {
            // Do some work that may result in a transient fault.
            await retryPolicy.ExecuteAsync(
                async () =>
                {
                    // TODO: replace with async ADO.NET calls.
                    await Task.Delay(1000);
                });
        }
        catch (Exception)
        {
            // All the retries failed.
        }
    }
