    /// <summary>
    /// Nancy converter to convert numeric types with InvariantCulture.
    /// </summary>
    public class NancyNumericConverter : ITypeConverter
    {
        public bool CanConvertTo(Type destinationType, BindingContext context)
        {
            return destinationType.IsNumeric();
        }
    
        public object Convert(string input, Type destinationType, BindingContext context)
        {
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }
    
            return System.Convert.ChangeType(input, destinationType, CultureInfo.InvariantCulture);
        }
    }
