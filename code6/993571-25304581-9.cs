    private static readonly Task<object> _completedTask = Task.FromResult<object>(null);
    
    public static void SafeExecute(Action actionThatMayThrowException)
    {
        SafeExecute(() =>
        {
            actionThatMayThrowException();
            return _completedTask;
        });
    }
