    public class PositionLevelConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values == System.Windows.DependencyProperty.UnsetValue || values.Length != 2)
                return string.Empty;
            
            var collection = values[1] as ObservableCollection<EmployeeLevel>;
            if (collection == null)
                return string.Empty;
            return collection.FirstOrDefault(n => n.LevelID == (int)values[0])?.DisplayName;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
