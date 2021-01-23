    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        bool booleanValue = (value as bool?).GetValueOrDefault();
        if (parameter != null)
        {
            if (parameter.ToString().Equals("not", StringComparison.OrdinalIgnoreCase))
            {
                booleanValue = !booleanValue;
            }
            else
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Invalid value for the BoolToVisibilityConverter parameter: '{0}'. The only valid values are null or 'not' (case insensitive)", parameter));
            }
        }
        return booleanValue ? Visibility.Visible : Visibility.Collapsed;
    }
