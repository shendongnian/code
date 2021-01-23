    public class DataGridDateColumn : DataGridBoundColumn
    {
        public string DateFormatString { get; set; }
        protected override void CancelCellEdit(FrameworkElement editingElement, object before)
        {
            var picker = editingElement as DatePicker;
            if (picker != null)
            {
                picker.SelectedDate = DateTime.Parse(before.ToString());
            }
        }
        protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
        {
            var element = new DatePicker();
            var binding = new Binding(((Binding)this.Binding).Path.Path) {Source = dataItem};
            if (DateFormatString != null)
            {
                binding.Converter = new DateTimeConverter();
                binding.ConverterParameter = DateFormatString;
            }
            element.SetBinding(DatePicker.SelectedDateProperty, this.Binding);
            return element;
        }
        protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            var element = new TextBlock();
            var b = new Binding(((Binding) Binding).Path.Path) {Source = dataItem};
            if (DateFormatString != null)
            {
                b.Converter = new DateTimeConverter();
                b.ConverterParameter = DateFormatString;
            }
            element.SetBinding(TextBlock.TextProperty, b);
            return element;
        }
        protected override object PrepareCellForEdit(FrameworkElement editingElement, RoutedEventArgs editingEventArgs)
        {
            var element = editingElement as DatePicker;
            if (element != null)
            {
                if (element.SelectedDate.HasValue ) return element.SelectedDate.Value;
            }
            return DateTime.Now;
        }
    }
    public class DateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var date = (DateTime)value;
            return date.ToString(parameter.ToString());
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime resultDateTime;
            if (DateTime.TryParse(value.ToString(), out resultDateTime))
            {
                return resultDateTime;
            }
            return value;
        }
    }
