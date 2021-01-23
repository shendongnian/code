    static class Extentions
    {
        public static System.Windows.Point Scale(this System.Windows.Point point, float scale)
        {
            return new System.Windows.Point((int)(point.X * scale), (int)(point.Y * scale));
        }
    }
