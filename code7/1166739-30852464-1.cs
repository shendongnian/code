    public static Task<T> AsyncPattern(Func<T> func)
    {
        var tcs = new TaskCompletionSource<T>();
        try
        {
            tcs.SetResult(func());
        }
        catch (Exception e)
        {
            tcs.SetException(e);
        }
        return tcs.Task;
    }
