    /// <summary>
    /// Converts a boolean value to a grid length which is specified with a converter
    /// parameter if the value is true, otherwise the grid lengthe will be zero.
    /// <para>
    /// If no parameter is specified the returned <see cref="Windows.UI.Xaml.GridLength"/> will be zero.
    /// If the parameter cannot be parsed to a grid length then the returned <see cref="Windows.UI.Xaml.GridLength"/> will be zero.
    /// If the value is a <see cref="bool"/> false, then the returned <see cref="Windows.UI.Xaml.GridLength"/> will be zero.
    /// </para>
    /// </summary>
    public sealed class BoolToGridLengthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (!(value is bool) || !(parameter is string))
            {
                return new GridLength(0);
            }
    
            if (!((bool)value))
            {
                return new GridLength(0);
            }
    
            var str = parameter as string;
            if (str.Equals("Auto"))
            {
                return new GridLength(0, GridUnitType.Auto);
            }
    
            if (str.Equals("*"))
            {
                return new GridLength(1, GridUnitType.Star);
            }
    
            if (str.EndsWith("*"))
            {
                var length = Double.Parse(str.Substring(0, str.Length - 1));
                return new GridLength(length, GridUnitType.Star);
            }
    
            var len = Double.Parse(str);
            return new GridLength(len);
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
