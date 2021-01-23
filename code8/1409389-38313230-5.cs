    public static async Task<IEnumerable<TResult>> SelectAsync<T, TResult>(
        this IEnumerable<T> list, 
             Func<T, Task<TResult>> functionToPerform)
    {
        var tasks = list.Select(functionToPerform.Invoke);
        return await Task.WhenAll(tasks).ConfigureAwait(false);
    }
