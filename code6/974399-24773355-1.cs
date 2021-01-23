    namespace CSharpWPF
    {
        public class ErrorToVisibilityConverter : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                DataGridColumn column = values[0] as DataGridColumn;
                ObservableCollection<DataColumnChangeEventArgs> errors = values[1] as ObservableCollection<DataColumnChangeEventArgs>;
                DataRowView view = values[2] as DataRowView;
                DataColumnChangeEventArgs args = errors.FirstOrDefault(e => (e.Row == view.Row) && (e.Column.Ordinal == column.DisplayIndex));
                return view.Row.HasErrors && args != null ? Visibility.Visible : Visibility.Collapsed;
            }
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
