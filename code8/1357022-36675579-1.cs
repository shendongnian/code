    public async Task DoWork()
    {
        await this.Operation1Async();
        this.Operation2().GetAwaiter().GetResult();
        this.Operation3().GetAwaiter().GetResult();
    }
