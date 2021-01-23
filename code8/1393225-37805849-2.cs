    public class IndexToDescriptionConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int index = (int)values[0];
            if(index < 0)
            {
                return null;
            }
            ObservableCollection<String> ColumnDescriptions = (ObservableCollection<String>)values[1];
            return ColumnDescriptions.ElementAt(index);
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
