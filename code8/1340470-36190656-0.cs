    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        var arrays = values
            .OfType<Array>()
            .Select(x => x.OfType<object>())
            .ToList();
        if (arrays.Count != 2) return DoubleCollectionWhenValueIsNull;
        return arrays[0].SequenceEqual(arrays[1]) ? DoubleCollectionWhenEqual : DoubleCollectionWhenNotEqual;
    }
