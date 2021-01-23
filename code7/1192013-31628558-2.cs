    class Combo
    {
        public string FirstComboBoxValue { get; set; }
        public string SecondComboBoxValue { get; set; }
    }
    class ComboBoxesToComboClassConverter: IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return new Combo()
            {
                FirstComboBoxValue = values[0].ToString(),
                SecondComboBoxValue = values[1].ToString()
            };
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
