    class IntConverter : IValueConverter
    {
      /// <summary>
      /// should try to parse your int or return 0 otherwise.
      /// </summary>
      public object Convert(object value,Type targetType,object parameter,CultureInfo culture)
      {
        int temp_int;
        return (Int32.TryParse(value, out temp_int)
           ? temp_int
           : 0;
      }
    
      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
      {
        throw new NotImplementedException();
      }
    }  
