    public static Func<Task<TResult>> Return<TResult>(
        this Func<Task> asyncAction, TResult result)
    {
        ArgumentValidate.NotNull(asyncAction, nameof(asyncAction));
    
        return () =>
        {
            var task = asyncAction();
            return AwaitAndReturn(task, result);
        };
    }
    public static async Func<Task<TResult>> AwaitAndReturn<TResult>(
        this Task asyncAction, TResult result)
    {
        await task;
        return result;
    }
