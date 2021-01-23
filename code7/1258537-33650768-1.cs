    public class Converter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var selectedValueList1 = values[0];
            var currentItemList2 = values[1];
            if(selectedValueList1 == null) // Listbox 1 has no selected Item
                return Brushes.Black;
            if (selectedValueList1 == currentItemList2)
                return Brushes.Red;
            return Brushes.Transparent;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
