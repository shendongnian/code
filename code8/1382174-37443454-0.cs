       public class OptionOrderBackgroundConverter : IValueConverter
       {
          public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
          {
             // Create a background and return
             bool b = (value != null ? (bool)value : false);
             if (!b)
             {
                LinearGradientBrush lb = new LinearGradientBrush();
                lb.StartPoint = new System.Windows.Point(0, 0);
                lb.EndPoint = new System.Windows.Point(0, 1);
                GradientStop gstop = new GradientStop(ViewModels.QuoteButtonStyle.Instance.QuoteButtonTopBackgroundColor, 0);
                lb.GradientStops.Add(gstop);
                gstop = new GradientStop(ViewModels.QuoteButtonStyle.Instance.QuoteButtonBottomBackgroundColor, 0.9);
                lb.GradientStops.Add(gstop);
                return lb;
             }
             else
             {
                LinearGradientBrush lb = new LinearGradientBrush();
                lb.StartPoint = new System.Windows.Point(0, 0);
                lb.EndPoint = new System.Windows.Point(0, 1);
                GradientStop gstop = new GradientStop(Colors.Orange, 0);
                lb.GradientStops.Add(gstop);
                gstop = new GradientStop(Colors.WhiteSmoke, 0.9);
                lb.GradientStops.Add(gstop);
                return lb;
             }
          }
          public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
          {
             throw new NotImplementedException();
          }
       }
