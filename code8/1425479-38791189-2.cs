    public class MsgToImagePathCovnerter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var imagePath = "ms-appx:///Assets/1.jpg";
            var msg = (bool)value;
            if (msg)
            {
                imagePath = "ms-appx:///Assets/2.jpg";
            }
            return imagePath;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
