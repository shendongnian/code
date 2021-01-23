    public static Func<Task<TResult>> Return<TResult>(this Func<Task> asyncAction, TResult result)
    {
        ArgumentValidate.NotNull(asyncAction, nameof(asyncAction));
    
        return () =>
        {
            // Call this synchronously
            var task = asyncAction();
            // Now create an async delegate for the rest
            Func<Task<TResult>> intermediate = async () => 
            {
                await task;
                return result;
            }
            return intermediate();
        };
    }
