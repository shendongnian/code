    public class DataGridCellToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string propertyToAppend = parameter as string;
            var cell = value as DataGridCell;
            var column = cell.Column as DataGridTextColumn;
            Binding b = column.Binding as Binding;
            Binding b1 = new Binding(string.Join(".", b.Path.Path, propertyToAppend)) { Source = cell.DataContext };
            CheckBox dummy = new CheckBox();
            dummy.SetBinding(CheckBox.IsCheckedProperty, b1);
            return dummy.IsChecked;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
