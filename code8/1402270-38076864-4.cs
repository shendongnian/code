    class LastItemConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            IEnumerable<object> items = value as IEnumerable<object>;
            if (items != null)
            {
                return items.LastOrDefault();
            }
            else return Binding.DoNothing;
        }
    
        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
