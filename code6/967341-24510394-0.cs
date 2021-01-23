    public sealed class ImagetoPathConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, string language)
            {
                if (value == null)
                {
                    return value = "ms-appx:///Assets/Images/bk/1.png";
                }
                else if (value.ToString() == "1")
                {
                    return value = "ms-appx:///Assets/Images/bk/2.png";
                }
                else if (value.ToString() == "2")
                {
                    return value = "ms-appx:///Assets/Images/bk/3.png";
                }
                        }
    
            public object ConvertBack(object value, Type targetType, object parameter, string language)
            {
                throw new NotImplementedException();
            }
        }
