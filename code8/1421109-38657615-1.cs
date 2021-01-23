    static class Extentions
    {
        public static System.Windows.Point Scale(this System.Windows.Point point, float scale)
        {
            return new System.Windows.Point(point.X * scale, point.Y * scale);
        }
    }
