    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
		_log.Warn("Warning. Reverse binding on MultiBoolConverter called. Prevent this by using OneWay.");
		List<object> result = new List<object>();
        foreach(var t in targetTypes)
        {
	        result.Add(Binding.DoNothing);
        }
        return result.ToArray();
    }
