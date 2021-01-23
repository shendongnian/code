    [ValueConversion(typeof(object), typeof(object))]
    public class IsCheckedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ObservableCollection<CheckServerItem> result = new ObservableCollection<CheckServerItem>();
            foreach(CheckServerItem item in (value as ObservableCollection<CheckServerItem>))
            {
                if (item.IsChecked)
                {
                    result.Add(item);
                }
            }
            return result;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
