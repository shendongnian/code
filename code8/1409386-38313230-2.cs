    public static Task ForEachAsync<T>(this IEnumerable<T> list, Func<T, Task> functionToPerform)
    {
        var tasks = list.Select(functionToPerform.Invoke);
        return Task.WhenAll(tasks).ConfigureAwait(false);
    }
    public static Task<IEnumerable<TU>> SelectAsync<T, TU>(this IEnumerable<T> list, Func<T, Task<TU>> functionToPerform)
    {
        var tasks = list.Select(functionToPerform.Invoke);
        return Task.WhenAll(tasks).ConfigureAwait(false);
    }
