    public class HealthColorConverter : IValueConverter
    {
      private static readonly Color ColorSick = Colors.Red;
      private static readonly Color ColorHealthy = Colors.LimeGreen;
      private static readonly SolidColorBrush ColorWarning = Colors.Yellow;
      public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
      {
        if (value is HealthStatus)
        {
            var health = (HealthStatus)value;
            switch (health)
            {
                case HealthStatus.Ok:
                    return ColorHealthy;
                case HealthStatus.Sick:
                    return ColorSick;
                case HealthStatus.Warning:
                    return ColorWarning;
                default:
                    return ColorSick;
                    //return DependencyProperty.UnsetValue;
            }
        }
        return value;
    }
    
