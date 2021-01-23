     public class VisiableOrNot : IValueConverter
     {
         public object Convert(object value, Type targetType, object parameter, string language)
         {
             Uri uri = new Uri(value.ToString());
             if (uri != null)
             {
                 if (uri.Equals("ms-appx:///View/Page3.xaml"))
                 {
                     return Visibility.Visible;
                 }
             }
             return Visibility.Collapsed;
         }
    
         public object ConvertBack(object value, Type targetType, object parameter, string language)
         {
             throw new NotImplementedException();
         }
     }
