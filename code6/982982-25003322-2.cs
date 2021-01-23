    public class AmountConverter : IMultiValueConverter
    {
        decimal quantity = 0m;
        decimal rate = 0m;
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (decimal.TryParse(values[0].ToString(), out quantity) && decimal.TryParse(values[1].ToString(), out rate))
            {
                return (quantity * rate).ToString();
            }
            return "0";
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            decimal amount = 0m;
            object[] values = new object[2];
            values[0] = quantity;
            values[1] = rate;
            if (decimal.TryParse(value.ToString(), out amount))
            {
                if (quantity != 0m)
                    values[1] = amount / quantity;
            }
            return values;
        }
    }
