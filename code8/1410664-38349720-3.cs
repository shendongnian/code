    public class PropBasedStringToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            object result = null;
    
            if (value == null) return "N/A";
    
            if (value.GetType() == typeof(DataGridTextColumn))
            { 
                string path = ((Binding)((DataGridTextColumn)value).Binding).Path.Path;
                return path;
            }
            else if (value.GetType() == typeof(string))
            {
                result = new SolidColorBrush((Color)ColorConverter.ConvertFromString(value.ToString()));
            }
            return result;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
