    public class RowToIndexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (value as DataGridRow).GetIndex();
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
        private static RowToIndexConverter _instance = new RowToIndexConverter(); 
        public static RowToIndexConverter Instance { get { return _instance; } }
    }
