    public class PersonToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
              SolidColorBrush brush = new SolidColorBrush();
              string personPosition = value.ToString();
              if(personPosition!=null && personPosition.Equals("Developer"))
              {
                    brush.Color = Colors.Green;
              }
              else
              {
                    brush.Color = Colors.White;
              }
              return brush;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return new NotImplementedException();
        }
    }
