    public class AccessLevelToVisibilityConverter : MarkupExtension, IMultiValueConverter
    {
        public object Convert( object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var visibility = Visibility.Hidden;
            var viewModel = (VariableDataViewModel)values[0];
            var item = (VariableDataItem)values[1];
            visibility = viewModel.IsVariableVisible(item);
            return visibility;
        }
        public object[] ConvertBack( object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
