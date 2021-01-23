    class IsFirstItemConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            ObservableCollection<NamedObject> col = (ObservableCollection<NamedObject>)values[0];
            if (col[0].Equals(values[1]))
                return true;
            else
                return false;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
