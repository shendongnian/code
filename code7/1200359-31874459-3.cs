    public IEnumerable<Item> GetItems()
    {
        var result = Children.SelectMany(i => i.GetItems()).ToList();
        result.Add(this);
        return result;
    }
