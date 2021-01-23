    System.Threading.Tasks.Task<T> DoIt<T>(Func<System.Threading.Tasks.Task<T>> func)
    {
        return func();
    }
    async System.Threading.Tasks.Task Main()
    {
        await DoIt(() => System.Threading.Tasks.Task.FromResult(1));
    
        await DoIt(() => System.Threading.Tasks.Task.FromResult(""));
    }
