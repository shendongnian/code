    public class NameConverter : IMultiValueConverter
    {
        public object Convert( object[] values
                             , Type targetType
                             , object parameter
                             , CultureInfo culture )
        {
            string name;
    
            switch ((string)parameter)
            {
                case "FormatLastFirst":
                    name = values[1] + ", " + values[0];
                    break;
                case "FormatNormal":
                default:
                    name = values[0] + " " + values[1];
                    break;
            }
    
            return name;
        }
    
        //  public object[] ConvertBack...
    }
     
