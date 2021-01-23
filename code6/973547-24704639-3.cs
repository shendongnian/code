    AddFilter<HookContainer<System.Func<object, object>>>("test", new HookContainer<System.Func<object, object>>());
You can change AddFilters to:
    ...
    public string AddFilter<T>(string filterName, string filterTag = null, int priority = 0) where T: new()
    {
        KeyValuePair<string, T> data = new KeyValuePair<string, T>(filterTag, new T());
    ...
