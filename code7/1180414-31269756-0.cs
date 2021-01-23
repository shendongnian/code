    public Task FooAsync(int x, int y)
    {
        if (x < y)
        {
            // This will be thrown straight to the caller, in the
            // normal way
            throw new ArgumentException("...");
        }
        return FooAsyncImpl(x, y);
    }
    private async Task FooAsyncImpl(int x, int y)
    {
        // Any exceptions thrown here will be propagated via the task
    }
