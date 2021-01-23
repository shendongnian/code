    public IEnumerable<Item> GetItems()
    {
        if (this.Children.Count == 0)
        {
            return new List<Item> { this };
        }
        var result = Children.SelectMany(i => i.GetItems()).ToList();
        result.Add(this);
        return result;
    }
