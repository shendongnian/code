    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
      long longValue;
      try {
        longValue = Convert.ToInt64(value);
      } catch {
        return Visibility.Visible;
      }
        
      if ((longValue & 0x0f) > 0) return Visibility.Collapsed;
      return Visibility.Visible;
    }
