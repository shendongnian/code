    public IEnumerable<Data> RemoveHandledForDate(IEnumerable<Data> data, DateTime dateTime)
    {
        Lazy<HashSet<DataIds>> ids = new Lazy<HashSet<DataIds>>(
            () => new HashSet<DataIds>(
           GetHandledDataForDate(dateTime) // Expensive database operation
              .Select(d => d.DataId)
        ));
        return data.Where(d => !ids.Value.Contains(d.DataId));
    }
