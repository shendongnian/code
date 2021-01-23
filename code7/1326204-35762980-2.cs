    private ConcurrentDictionary<string, Lazy<Task<string>>> dict = 
        new ConcurrentDictionary<string, Lazy<Task<string>>>();
    
    public Task ProcessSomeThing(string input)
    {
        return dict.AddOrUpdate(
            input, 
            key => new Lazy<Task<string>>(() => 
                GetSomeValueFromAsyncMethod(key), 
                LazyThreadSafetyMode.ExecutionAndPublication),
            (key, existingValue) => new Lazy<Task<string>>(() => 
                GetSomeValueFromAsyncMethod(key), // unless you want the old value
                LazyThreadSafetyMode.ExecutionAndPublication)).Value;
    }
