    public class MultiConverter : IMultiValueConverter
    {
        public object Convert(
            object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is MyColorType &&
                values[1] is MyColorType &&
                // if ComboBox.SelectedColor == CurrentDataGridRow.ColorColumn
                (MyColorType)values[0] == (MyColorType)values[1])
                return true;
            return false;
        }
        public object[] ConvertBack(
            object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
