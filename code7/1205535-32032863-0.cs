        public enum ColorFormat
        {
            RGB, RGBA, ARGB
        }
        public static int ColorToDecimal(Color color, ColorFormat format = ColorFormat.RGB)
        {
            switch (format)
            {
                default:
                case ColorFormat.RGB:
                    return color.R << 16 | color.G << 8 | color.B;
                case ColorFormat.RGBA:
                    return color.R << 24 | color.G << 16 | color.B << 8 | color.A;
                case ColorFormat.ARGB:
                    return color.A << 24 | color.R << 16 | color.G << 8 | color.B;
            }
        }
        public static Color DecimalToColor(int dec, ColorFormat format = ColorFormat.RGB)
        {
            switch (format)
            {
                default:
                case ColorFormat.RGB:
                    return Color.FromArgb((dec >> 16) & 0xFF, (dec >> 8) & 0xFF, dec & 0xFF);
                case ColorFormat.RGBA:
                    return Color.FromArgb(dec & 0xFF, (dec >> 24) & 0xFF, (dec >> 16) & 0xFF, (dec >> 8) & 0xFF);
                case ColorFormat.ARGB:
                    return Color.FromArgb((dec >> 24) & 0xFF, (dec >> 16) & 0xFF, (dec >> 8) & 0xFF, dec & 0xFF);
            }
        }
