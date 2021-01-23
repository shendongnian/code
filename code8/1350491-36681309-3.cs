     public class Converter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            CheckBox FE = values[0] as CheckBox;
            List<BindingExpression> bindings = values[1] as List<BindingExpression>;
            bindings.Add(FE.GetBindingExpression(CheckBox.IsCheckedProperty));
            return null;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
