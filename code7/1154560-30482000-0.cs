    public TDest ConvertValue<TSrc, TDest>(TSrc src, Func<TDest, TDest> adapter = null)
    {
        var converted = Convert.ChangeType(src, typeof(TDest), CultureInfo.InvariantCulture);
        if (adapter == null)
        {
            adapter = GetDefaultAdapter<TDest>();
        }
        return adapter(converted);
    }
    private static readonly Hashtable DefaultAdapters = InitializeAdapters();
    private static Hashtable InitializeAdapters()
    {
        var hashtable = new Hashtable
        {
            {typeof (DateTime).Name, (Func<DateTime, DateTime>)(t => DateTime.SpecifyKind(t, t.ToUniversalTime())},
        };
        return hashtable;
    }
    public static Func<T, T> GetDefaultAdapter<T>()
    {
        Func<T, T> ret = f => f;
        if (DefaultAdapters.ContainsKey(typeof(T).Name))
        {
            ret = (Func<T, T>)DefaultAdapters[typeof(T).Name];
        }
        return ret;
    }
