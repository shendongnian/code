    public class ListConverter : IValueConverter
    {
        public object Convert(object value, 
            Type targetType, 
            object parameter, 
            System.Globalization.CultureInfo culture)
        {
            var vm = value as MyViewModelType;
            var type = (String)parameter;
            return new List<String>
            {
                "Test1" + type,
                "Test2" + type
            };
        }
        public object ConvertBack(object value, 
            Type targetType, 
            object parameter, 
            System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
