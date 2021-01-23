    public class NameToImageConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // here you can return DrawingImage based on value that represents name field of your structure
            // just for example the piece of your code:
            return SvgReader.Load(new MemoryStream(new System.Net.WebClient().DownloadData("http://upload.wikimedia.org/wikipedia/commons/c/c5/Logo_FC_Bayern_München.svg")));
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
