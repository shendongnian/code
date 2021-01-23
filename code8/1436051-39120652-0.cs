        public int getSample(int x, int y, int band)
        {
            //return image.getRaster().getSample(x, y, band);
            var pixelColor = image.GetPixel(x, y);
            switch (band)
            {
                case 0: return pixelColor.R;
                case 1: return pixelColor.G;
                case 2: return pixelColor.B;
            }
            throw new ArgumentException(nameof(band));
        }
        public void setSample(int x, int y, int band, int value)
        {
            //image.getRaster().setSample(x, y, band, value);
            var oldColor = image.GetPixel(x, y);
            Color newColor;
            switch (band)
            {
                case 0:
                    newColor = Color.FromArgb(255, value, oldColor.G, oldColor.B);
                    break;
                case 1:
                    newColor = Color.FromArgb(255, oldColor.R, value, oldColor.B);
                    break;
                case 2:
                    newColor = Color.FromArgb(255, oldColor.R, oldColor.G, value);
                    break;
                default:
                    throw new ArgumentException(nameof(band));
            }
            image.SetPixel(x, y, newColor);
        }
