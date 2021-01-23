    public class BytesToImageConverter : IValueConverter
    {
   
        public object Convert(object value, Type typeName, object parameter, string language)
        {
            if (value != null && value is byte[])
            {
                byte[] bytes = value as byte[];
                Stream stream = new MemoryStream(bytes);
                BitmapImage image = new BitmapImage();
                image.SetSourceAsync(new MemoryRandomAccessStream(stream));
                return image;
            }
            return null;
        }
        public object ConvertBack(object value, Type typeName, object parameter, string language)
        {
            throw new NotImplementedException();
        }
   
    }
