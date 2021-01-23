    public class PictureConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
            {
                return null;
            }
            string item = value.ToString();
            BitmapImage objBitmapImage = new BitmapImage();
            objBitmapImage = NewViewModel.Base64StringToBitmap(item);
            return objBitmapImage;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
