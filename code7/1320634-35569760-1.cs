    public class MultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DesignerCanvas cavas = values[0] as DesignerCanvas;
            Connector source= values[1] as Connector;
            Point p = source.TranslatePoint(new Point(0, 0), canvas);
            p.X += source.Width / 2.0d;
            // and so on
           
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
