    class LoadPercentValueConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                long percent = (long)System.Convert.ChangeType(value, typeof(long));
                if (percent > 80)
                {
                    return 1;
                }
    
                else
                {
                    return 0;
                }
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
