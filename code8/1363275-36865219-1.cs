    public class MyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            object obj = ((System.Reflection.PropertyInfo)value).GetValue(this,null);           
            return (SolidColorBrush)new BrushConverter().ConvertFromString(obj.ToString());
        }
        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            return value;
        }
    }
