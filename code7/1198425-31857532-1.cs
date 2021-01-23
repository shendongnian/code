    public class TruncatedDecimal : IFormattable
    {
        private decimal value;
    
        public TruncatedDecimal(decimal doubleValue)
        {
            value = doubleValue;
        }
    
        public decimal Value
        {
            get
            {
                return value;
            }
        }
    
        public string ToString(string format, IFormatProvider formatProvider)
        {
            int decimalDigits = Int32.Parse(format.Substring(1));
            decimal mult = (decimal)Math.Pow(10, decimalDigits);
            decimal trucatedValue = Math.Truncate(value * mult) / mult;
            
            return trucatedValue.ToString(format, formatProvider);
        }
    }
