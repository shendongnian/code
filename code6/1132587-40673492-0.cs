       public class MyConverter : IValueConverter
        {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter != null)
            {
                try
                {
                    var image = parameter as Image;
                    var src = image.Source as FileImageSource;
                    if (src.File.ToString() == "coolimage.png")
                    {
                        return "thumbsup.png";
                    }
                }
                catch
                {
                }
            } 
        }
