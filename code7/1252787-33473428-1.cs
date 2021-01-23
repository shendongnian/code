    using System;
    using System.Windows.Data;
    
    public class TimeSpanConverter : IValueConverter
    {
      public object Convert(object value,
                            Type targetType,
                            object parameter,
                            CultureInfo culture)
      {
        // I am using following extension method here: http://stackoverflow.com/a/4423615/57508
        var timeSpan = (TimeSpan) value;
        var result = timeSpan.ToReadableString();
        return result;
      }
    
      public object ConvertBack(object value,
                                Type targetType,
                                object parameter,
                                CultureInfo culture)
      {
        throw new NotImplementedException();
      }
    }
