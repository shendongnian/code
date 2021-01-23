    public static class Extensions
    {
        public static bool Overlaps(this Rectangle source, Rectangle other)
        {
            if (source.Left > other.Right || other.Left > source.Right) return false;
            if (source.Top > other.Bottom || other.Top > source.Bottom) return false;
            return true;
        }
    }
