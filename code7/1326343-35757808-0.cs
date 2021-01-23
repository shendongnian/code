    public List<ChartItemData> myMethod(List<ChartItemData> myList, string propName, SortDirection direction)
    {
        var desiredProperty = typeof(ChartItemData).GetProperty(propName, BindingFlags.Public | BindingFlags.Instance);
        if (direction == SortDirection.Ascending)
            return myList.OrderBy(x => desiredProperty.GetValue(x)).ToList();
        else
            return myList.OrderByDescending(x => desiredProperty.GetValue(x)).ToList();
    }
