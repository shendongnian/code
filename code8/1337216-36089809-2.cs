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
        //year,dayOfYear/Time(HHmmss)
        var parts = strValue.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 2) {
            var year = parts[0];
            parts = parts[1].Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 2) {
                var days = parts[0];
                var time = parts[1];
                var date = new DateTime(int.Parse(year), 1, 1)
                                .AddDays(int.Parse(days))
                                .Add(TimeSpan.Parse(time));
                return date;
            }
        }
        DateTime resultDateTime;
        return DateTime.TryParse(strValue, out resultDateTime) ? resultDateTime : value;
    }
