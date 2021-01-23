        public object Convert(object[] value, Type targetType, object parameter,
                System.Globalization.CultureInfo culture)
        {
            if (value[0].GetType() == typeof(HashSet<string>))
            {
                if (value[1].GetType() == typeof(string))
                {
                    if (((HashSet<string>)value[0]).Contains((string)value[1]))
                        return Visibility.Visible;
                }
            }
            return Visibility.Collapsed;
        }
