        using System;
        using System.Globalization;
        using System.Windows.Data;
        using System.Windows.Media;
        
        namespace WPFTest.Converters
        {
          public class ColorToBrush : IValueConverter
          {
            public virtual object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
              return value is Color ? new SolidColorBrush((Color)value) : Brushes.Black;
            }
        
            public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
              throw new NotImplementedException();
            }
          }
        }
