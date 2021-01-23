    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null) return null;
        string strValue = value.ToString();
        if (string.IsNullOrEmpty(strValue) && targetType == typeof(DateTime?))
        {
            return null;
        }
        else if (string.IsNullOrEmpty(strValue))
        {
            return DateTime.MinValue;
        }
        DateTime resultDateTime;
        return DateTime.TryParse(strValue, out resultDateTime) ? resultDateTime : value;
    }
