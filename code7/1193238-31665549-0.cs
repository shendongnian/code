    class MyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
               object parameter, System.Globalization.CultureInfo culture)
        {
            contactString = value as string;
            if(contactString == null)
            {
                 throw new InvalidArgumentException();
            }
            
            return string.Format("({0}) {1}-{2}",
              contactString.Substring(0,3), contactString.Substring(4,3),
              contactString.Substring(7,3));
        }
    
        public object ConvertBack(object value, Type targetType,
              object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
