    /// <summary>Converts the value into a time only formatted string.</summary>
    /// <param name="value"> The value. </param>
    /// <param name="targetType"> The target type. </param>
    /// <param name="parameter"> The parameter. </param>
    /// <param name="culture"> The culture. </param>
    /// <returns>Time string value. </returns>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var escapedFormatString = parameter.replace(@":", @"\:");
        return ((TimeSpan)value).ToString(escapedFormatString);
    }
