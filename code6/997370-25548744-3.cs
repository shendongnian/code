    [ValueConversion(typeof(string), typeof(ImageSource))]
        class Converter_StringToImageSource : MarkupExtension, IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                try
                {
                    var key = (value as string ?? parameter as string);
    
                    if (!string.IsNullOrEmpty(key))
                    {
                        // Do translation based on the key
                        if (File.Exists(key))
                        {
                            var source = new BitmapImage(new Uri(key));
                            return source;
                        }
                        else
                        {
                            var source = new BitmapImage(new Uri(Utils.GetPicturePath(key)));
                            return source;
                        }
                       
                    }
                    return Utils.GetEmpty();
                }
                catch (Exception)
                {
                    return Utils.GetEmpty();
                }
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
    
            public Converter_StringToImageSource()
                : base()
            {
            }
    
            private static Converter_StringToImageSource _converter = null;
    
            public override object ProvideValue(IServiceProvider serviceProvider)
            {
                if (_converter == null) _converter = new Converter_StringToImageSource();
                return _converter;
            }
        }
