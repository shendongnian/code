    public class StringToBoolConverter : IValueConverter
    {
       public object Convert(...)
       {
           return value.ToString() != "0";
       }
    
       public object ConvertBack(...)
       {
           bool boolVal = (bool)value;
           return boolVal ? "1" : "0";
       }
    }
