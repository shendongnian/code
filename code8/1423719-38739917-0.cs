    public class SumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            CollectionViewGroup group = (CollectionViewGroup)value;            
            ReadOnlyObservableCollection<object> items = group.Items;
            var sum = (from p in items select ((ProjectCompletedModel)p).SomeValueToSum).Sum();
            return sum;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
