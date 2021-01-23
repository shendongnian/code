    public static void Filter(IList<SelectedFilter> selectedFilters)
    {
        var shirts = db.GetAllShirts();
        var selectedShirts = selectedFilters
            .GroupBy(i => i.Name)
            .SelectMany(filter => FilterShirts(filter, shirts))
            .Distinct();
    }
    public static IEnumerable<Shirt> FilterShirts(
        IGrouping<string, SelectedFilter> filter,
        IEnumerable<Shirt> shirts)
    {
        var values = filter.Select(i => i.Value);
        switch (filter.Key)
        {
            case "Color":
                return shirts.Where(shirt => values.Contains(shirt.Color));
            case "Size":
                return shirts.Where(shirt => values.Contains(shirt.Size));
            case "Type":
                return shirts.Where(shirt => values.Contains(shirt.Type));
            default:
                return Enumerable.Empty<Shirt>();
        }
    }
