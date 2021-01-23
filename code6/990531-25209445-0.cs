    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        switch ((Suit)value)
        {
            case Suit.Spades:
                return ConvertToBitmapImage(Resources.Spades);
            case Suit.Hearts:
                return ConvertToBitmapImage(Resources.Hearts);
            case Suit.Clubs:
                return ConvertToBitmapImage(Resources.Clubs);
            case Suit.Diamonds:
                return ConvertToBitmapImage(Resources.Diamonds);
            default:
                return null;
        }
    }
    private static BitmapImage ConvertToBitmapImage(Bitmap bitmap)
    {
        BitmapImage img = new BitmapImage();
        img.BeginInit();
        MemoryStream stream = new MemoryStream();
        bitmap.Save(stream, ImageFormat.Bmp);
        stream.Seek(0, SeekOrigin.Begin);
        img.StreamSource = stream;
        img.EndInit();
        return img;
    }
