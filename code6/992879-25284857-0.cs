    public class CurrencyConverter : ConverterBase
    {
        private NumberFormatInfo nfi = new NumberFormatInfo();
        public CurrencyConverter()
        {
            nfi.NegativeSign = "-";
            nfi.NumberDecimalSeparator = ".";
            nfi.NumberGroupSeparator = ",";
            nfi.CurrencySymbol = "$";
        }
        
        public override object StringToField(string from)
        {
            return decimal.Parse(from, NumberStyles.Currency, nfi);
        }
    }
