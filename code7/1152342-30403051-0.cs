    public static Task WhenAny(IEnumerable<Task> tasks)
    {
        return Task.WhenAny(tasks).Unwrap();
    }
    public static Task<T> WhenAny<T>(IEnumerable<Task<T>> tasks)
    {
        return Task.WhenAny(tasks).Unwrap();
    }
    //TODO add wrappers for the `params` overloads if you want them too
