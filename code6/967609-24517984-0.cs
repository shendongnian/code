    class MyConverter : IMultiValueConverter
    {
      public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
      {
        decimal v1 = (decimal)values[0];
        decimal v2 = (decimal)values[1];
        decimal res = v1 != 0 ? v1 : v2;
        return res.ToString();
      }
      public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
      {
        string[] splitValues = ((string)value).Split(' ');
        return splitValues;
      }
    }
