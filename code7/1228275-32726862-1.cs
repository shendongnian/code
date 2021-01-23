    public class DefaultQtyConverter : IValueConverter
    {
        object val;
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                if (((<Your Model>)value).<property to check> == 0)
                    val = String.Empty; 
                else
                    val = ((<Your Model>)value).<property to check>;
            }
            catch { }
            return val;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
