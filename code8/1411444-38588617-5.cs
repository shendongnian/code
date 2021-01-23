    [ValueConversion(typeof(string), typeof(string))]
    public class FieldValueConverter : IValueConverter {
      public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
        bool isOld = (bool)parameter;
        string[] fieldValues = value.ToString().Split(new string[] {"|||"}, System.StringSplitOptions.None);
    
        string fieldValue = "";
        if (isOld)
          fieldValue = fieldValues[0];
        else if (!isOld && fieldValues.Length == 2)
          fieldValue = fieldValues[1];
        return fieldValue;
      }
    
      public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
        throw new NotImplementedException("Back conversion of comparison fields is not supported.");
      }
    }
