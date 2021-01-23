    public IEnumerable<Data> RemoveHandledForDate(IEnumerable<Data> data, DateTime dateTime)
    {
        var dataWrapper = new CachedEnumerable(data);
        ...
    }
