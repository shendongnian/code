    public static class FilterExtensions
    {
        public static PointF ToPointF(this AForge.Point source)
        {
            return new PointF(source.X, source.Y);
        }
    }
