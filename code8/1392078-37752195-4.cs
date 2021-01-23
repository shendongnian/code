    public static class ExtensionMethods
    {
        public static bool TryFirst<T>(this IEnumerable<T> @this, Func<T, bool> predicate, out T result)
        {
            foreach (var item in @this)
            {
                if (predicate(item))
                {
                    result = item;
                    return true;
                }
            }
            result = default(T);
            return false;
        }
    }
    //Used like
    Lock.EnterReadLock();
    try
    {
        KeyValuePair<string, string> result;
        bool found = Collection.TryFirst(kvp => kvp.Key == key, out result);
        if (found)
        {
            return result.Value;
        }
    }
    finally
    {
        Lock.ExitReadLock();
    }
