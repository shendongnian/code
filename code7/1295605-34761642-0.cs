    // Various names to be more conventional/readable
    public List<Items> LoadLineItemsById(IEnumerable<long> ids)
    {
        var idList = ids.ToList();
        return CurrentSession.Query<LineItem>()
                             .Where(item => isList.Contains(item.Id))
                             .ToList();
    }
