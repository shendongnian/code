    public static IReadOnlyList<SomeItem> OrderedList
    {
        get
        {
            return items.OrderBy(item => item.OrderId).ToList().AsReadOnly();
        }
    }
