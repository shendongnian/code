    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if (System.Convert.ToBoolean(value))
                {
                    return parameter;
                }
                return Binding.DoNothing;
            }
