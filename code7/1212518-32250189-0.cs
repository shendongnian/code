    public static void InvokeAs<T>(this object obj, Action<T> action)
    {
        action((T) obj);
    }
    public static TResult InvokeAs<T, TResult>(this object obj, Func<T, TResult> func)
    {
        return func((T) obj);
    }
