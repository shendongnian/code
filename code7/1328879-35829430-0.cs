    public class ClipWithConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var clipped = (Shape)values[0];
            var clip = (Shape)values[1];
            var clippedPos = new Point(Canvas.GetLeft(clipped), Canvas.GetTop(clipped));
            var clipPos = new Point(Canvas.GetLeft(clip), Canvas.GetTop(clip));
            var deltaVector = clipPos - clippedPos;
            var geometry = clip.RenderedGeometry.Clone();
            geometry.Transform = new TranslateTransform(deltaVector.X, deltaVector.Y);
            return geometry;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
