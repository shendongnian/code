                            Color oldColor = Color.FromArgb(rgbValues[position + 2], rgbValues[position + 1], rgbValues[position]);                           
                            Color screenProduct = ScreenBlend(oldColor, white);
                            Color newColorScreen = CalculateColorWithAlpha(oldColor, screenProduct, .30f);
        public Color ScreenBlend(Color Base, Color Overlay)
        {
            var float_Red = 1 - (1 - RGB_ByteToFloat(Base.R)) * (1 - RGB_ByteToFloat(Overlay.R));
            var float_Green = 1 - (1 - RGB_ByteToFloat(Base.G)) * (1 - RGB_ByteToFloat(Overlay.G));
            var float_Blue = 1 - (1 - RGB_ByteToFloat(Base.B)) * (1 - RGB_ByteToFloat(Overlay.B));
            var byte_Red = RGB_FloatToByte(float_Red);
            var byte_Green = RGB_FloatToByte(float_Green);
            var byte_Blue = RGB_FloatToByte(float_Blue);
            //this.ScreenColorBase.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(Base.R, Base.G, Base.B));
            //this.ScreenColorOverlay.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(Overlay.R, Overlay.G, Overlay.B));
            //this.ScreenColorResult.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(byte_Red, byte_Green, byte_Blue));
            //this.ScreenColorTarget.Background = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(166, 168, 248));
            return Color.FromArgb(byte_Red, byte_Green, byte_Blue);
        }
        public Color CalculateColorWithAlpha(Color Base, Color Over, float Alpha)
        {
            var finalRed = Alpha * Over.R + (1 - Alpha) * Base.R;
            var finalGreen = Alpha * Over.G + (1 - Alpha) * Base.G;
            var finalBlue = Alpha * Over.B + (1 - Alpha) * Base.B;
            return Color.FromArgb((int)finalRed, (int)finalGreen, (int)finalBlue);
        }
