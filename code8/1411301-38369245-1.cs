    public void Restore(IEnumerable<StorageItem> items)
    {
        foreach (var item in items)
            item.Restore(_serviceController);
    }
