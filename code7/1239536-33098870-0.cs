    public object Convert(object value, Type targetType, object parameter, string language) {
            BitmapImage image = (BitmapImage)value;
            
            image.DecodePixelType = DecodePixelType.Logical;
            if (image.PixelHeight >= image.PixelWidth) {
                image.DecodePixelHeight = 100;
            }
            else {
                image.DecodePixelWidth = 100;
            }
            return image;
        }
