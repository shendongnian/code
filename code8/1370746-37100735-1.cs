    [ValueConversion(typeof(Point), typeof(Transform))]
    public class PointToTransformConverter : MarkupExtension, IValueConverter
    {
        private static PointToTransformConverter _instance = null;
    
        public object Convert(
            object value, 
            Type targetType, 
            object parameter, 
            CultureInfo culture)
        {
            var point = (Point)value;
    
            return new TransformGroup
            {
                Children = new TransformCollection
                {
                    new TranslateTransform(point.X, point.Y)
                }
            };
        }
    
        public object ConvertBack(
            object value, 
            Type targetType, 
            object parameter, 
            CultureInfo culture)
        {
            var transform = value as TransformGroup;
            if (transform?.Children.Count > 0)
            {
                var translateTransform = transform.Children[0] as TranslateTransform;
                if (translateTransform != null)
                {
                    return new Point(
                        translateTransform.X, 
                        translateTransform.Y);
                }
            }
    
            return null;
        }
    
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _instance ?? (_instance = new PointToTransformConverter());
        }
    }
