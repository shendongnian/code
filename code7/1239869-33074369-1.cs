    public static class PixelExtensions
    {
        public static int ToPixel(this int val)
        {
            float scale = Application.Context.Resources.DisplayMetrics.Density;
            int pixels = (int)(val * scale + 0.5f);
            return pixels;
        }
        public static int ToSizeUnit(ComplexUnitType toUnit, int value)
        {
            return Convert.ToInt32(TypedValue.ApplyDimension(toUnit, value, Application.Context.Resources.DisplayMetrics));
        }
    }
