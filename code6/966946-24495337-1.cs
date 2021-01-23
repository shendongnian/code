    public class MaintenaceColorConverter : IValueConverter
    {
        public Color NormalColor { get; set; }
        public Color NoMaintenanceRequiredColor { get; set; }
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value.ToString() == "No Maintenance Required")
                return NoMaintenanceRequiredColor;
            
            return NormalColor;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
