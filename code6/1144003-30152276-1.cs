    public static class PointExtensions
    {
        public static PointF ToPointF(this AForge.Point source)
        {
            return new PointF(source.X, source.Y);
        }
    }
