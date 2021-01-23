    public class IsEnabledConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var cell = value as DataGridCell;
            var rowData = cell.DataContext as DataFroGrid; // data object bound to the row
            // you may analyze column info, row data here and make a decision
            if (cell.Column.Header.ToString()=="ColumnName1")
            {                
                return false;
            }
            return true;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
