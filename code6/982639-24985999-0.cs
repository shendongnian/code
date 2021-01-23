    public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        var value = values.Where(v => v != null).FirstOrDefault();
        return value == null ? Binding.DoNothing : value;
    }
