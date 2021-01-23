    public static IEnumerable<T> Cast<T>(this IEnumerable source)
    {
        foreach (var item in source)
            yield return (T)item; // representation preserving since IDataReader implements IDataRecord
    }
