    public class CollectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is ObservableCollection<TestData>)
            {
                return new ObservableCollection<TabItem>(((ObservableCollection<TestData>)value).
                    Select(q => q.tiTestTab));
            }
            return null;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
