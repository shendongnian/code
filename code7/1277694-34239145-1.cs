    public class CurrencyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Item valueAsItem = value as Item;
            if (valueAsItem != null)
            {
                double amount = valueAsItem.SomeNumber;
                if (amount == 0)
                {
                    return "-"; //In the question this is the display for 0.
                }
                if (amount < 0)
                {
                    amount *= -1; //In the question the numbers always display positive.
                }
                //In the question this is the format for the numbers.
                return valueAsItem.CurrencySymbol + amount.ToString("### ### ###.###");
            }
            return string.Empty;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
