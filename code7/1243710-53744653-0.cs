    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        var list = value as IEnumerable<ObservableStringExt>;
		if (list != null)
		{
			return list.Select(x => Convert(x, typeof(string), null, culture));
		}
        if (value is ObservableStringExt)
            return (value as ObservableStringExt).StrItem;
    }
