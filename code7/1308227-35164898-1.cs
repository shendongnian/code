        using System;
        using System.Globalization;
        using System.Windows.Media;
        
        namespace WPFTest.Converters
        {
          public class InvertColorToBrush : ColorToBrush
          {
            public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
              if (value is Color)
              {
                Color color = (Color)value;
                int iCol = ((color.A << 24) | (color.R << 16) | (color.G << 8) | color.B) ^ 0xffffff;
                Color inverted = Color.FromArgb((byte)(iCol >> 24),
                                                (byte)(iCol >> 16),
                                                (byte)(iCol >> 8),
                                                (byte)(iCol));
        
                return base.Convert(inverted, targetType, parameter, culture);
              }
              else
              {
                return Brushes.Black;
              }
            }
        
            public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
              throw new NotImplementedException();
            }
          }
        }
