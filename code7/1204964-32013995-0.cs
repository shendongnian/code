    public class GroupToBooleanConverter : IValueConverter
    {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                var selectedGroup = value as string;
                var buttonGroup = (string)parameter;
    
                return buttonGroup.Equals(selectedGroup);
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
