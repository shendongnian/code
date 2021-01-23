    public class DisplayConverter : IValueConverter
            {
                public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
                {
                    if (value == null) return "";
                    if ((bool) value) return "In Progress";
                    return "Finished";
                }
    
                public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
                {
                    throw new NotImplementedException();
                }
            }
