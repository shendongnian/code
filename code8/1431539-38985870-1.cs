    public static void Filter(IList<SelectedFilter> selectedFilters)
    {
        var filters = selectedFilters
            .GroupBy(i => i.Name);
        var filteredShirts = db
            .GetAllShirts()
            .Where(shirt => filters.All(filter => ShirtInFilter(filter, shirt)));
    }
    public static bool ShirtInFilter(
        IGrouping<string, SelectedFilter> filter,
        Shirt shirt)
    {
        var values = filter.Select(i => i.Value);
        switch (filter.Key)
        {
            case "Color":
                return values.Contains(shirt.Color);
            case "Size":
                return values.Contains(shirt.Size);
            case "Type":
                return values.Contains(shirt.Type);
            default:
                return false;
        }
    }
