    public IEnumerable<Item> GetItems()
    {
        if (this.Children.Count == 0)
        {
            return new List<Item> { this };
        }
        return Children.SelectMany(i => GetItems(i));
    }
