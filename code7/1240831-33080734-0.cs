      public class StatConverter : IValueConverter
      {
        #region IValueConverter Members
    
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
          if (value is int)
          {
            return (int)value == 1;
          }
    
          return false;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
          throw new NotImplementedException();
        }
    
        #endregion
      }
