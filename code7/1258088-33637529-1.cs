    public IEnumerable<Data> RemoveHandledForDate(IEnumerable<Data> data, DateTime dateTime)
    {
        var ids = new Lazy<HashSet<int>>(
            () => new HashSet<int>(
           GetHandledDataForDate(dateTime) // Expensive database operation
              .Select(d => d.DataId)
        ));
        return data.Where(d => !ids.Value.Contains(d.DataId));
    }
