    public class ContactDetailInfoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
              SolidColorBrush brush = new SolidColorBrush();
              string personPosition = value.ToString();
              if(person!=null && person.Equals("Developer"))
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
