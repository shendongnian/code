    public void UpdateList(IDictionary<int, int> sortOrder)
    {
        var current = GetList();
        foreach (var item in current)
        {
            int value;
            if (sortOrder.TryGetValue(item.Id, out value))
            {
                item.SortOrder = value;
            }
        }
    }
