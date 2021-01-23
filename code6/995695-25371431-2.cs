      namespace Omega.Operation.Converters
        {
        
         public class EndplateAnswerFilterConverter : CoverterBase<EndplateAnswerFilterConverter>, 
                                                           System.Windows.Data.IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
               lock (syncObject)
               {}
            }
         
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
              lock (syncObject)
                {}       
            }
        }
        }
