    public class StringToBitmapConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
            string source = value.ToString();
    var ims = new InMemoryRandomAccessStream();
        var bytes = Convert.FromBase64String(source);
        var dataWriter = new DataWriter(ims);
        dataWriter.WriteBytes(bytes);
        dataWriter.StoreAsync();
        ims.Seek(0);
        var img = new BitmapImage();
        img.SetSource(ims);
        return img;
            }
    return null;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
