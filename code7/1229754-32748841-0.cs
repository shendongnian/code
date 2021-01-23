    public class BinaryToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return null;
            if (value is IEnumerable<byte>)
            {
                List<byte> imgData = new List<byte>((IEnumerable<byte>)value);
                BitmapImage rval = new BitmapImage();
                rval.SetSource(new System.IO.MemoryStream(imgData.ToArray()));
                return rval;
            }
            throw new NotImplementedException();
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
