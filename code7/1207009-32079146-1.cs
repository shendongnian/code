    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string currentItem = string.Format("{0}", value);
            DateTime currentDate = DateTime.MinValue;
            if (DateTime.TryParse(currentItem, out currentDate))
            {
                if (DateTime.Today.Equals(currentDate))
                    return new SolidColorBrush(Colors.Green);
            }
            return new SolidColorBrush(Colors.Red);
        }
