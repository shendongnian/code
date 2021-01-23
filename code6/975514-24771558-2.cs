    namespace CSharpWPF
    {
        public class ElementToTrianglePointsConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                FrameworkElement element = value as FrameworkElement;
                PointCollection points = new PointCollection();
                Action fillPoints = () =>
                    {
                        points.Clear();
                        points.Add(new Point(element.ActualWidth / 2, 0));
                        points.Add(new Point(element.ActualWidth, element.ActualHeight));
                        points.Add(new Point(0, element.ActualHeight));
                    };
                fillPoints();
                element.SizeChanged += (s, ee) => fillPoints();
                return points;// store;
            }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
