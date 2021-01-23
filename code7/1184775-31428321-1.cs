            public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                if ((values[0] as String).Length <= 0)
                    return ""; // prevents error messages for binds on element names
    
                return Get((String)values[0]);
            }
    
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
            {
                return null;
            }
