    public static Task<TResult[]> SelectAsync<T, TResult>(
        this IEnumerable<T> list, 
             Func<T, Task<TResult>> functionToPerform)
    {
        var tasks = list.Select(functionToPerform.Invoke);
        return Task.WhenAll(tasks);
    }
