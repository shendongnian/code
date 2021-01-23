    public static class PointExtensions
    {
        public static Point ToSystem(this Point point, Bitmap bitmap)
        {
            return new Point(point.X + 100, bitmap.Height - point.Y - 100);
        }
    }
