    public class StatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch ((int)value)
            {
                case 1:
                    return "Raised";
                case 2:
                    return "Work in Progress";
                case 3:
                    return "Resolved";
                case 4:
                    return "Closed";
                default:
                    return "undefined";
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch (value.ToString())
            {
                case "Raised":
                    return 1;
                case "Work in Progress":
                    return 2;
                case "Resolved":
                    return 3;
                case "Closed":
                    return 4;
                default: 
                    return 0;
            }
        }
    }
