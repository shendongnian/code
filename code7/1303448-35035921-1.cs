    public class DataGridAttached
    {
        public static readonly DependencyProperty ColumnActualWidthProperty = DependencyProperty.RegisterAttached(
            "ColumnActualWidth", typeof (double), typeof (DataGridAttached), new PropertyMetadata(default(double), ColumnActualWidthPropertyChanged));
        private static void ColumnActualWidthPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var data = d.FindParent<DataGrid>();
            var control = (d as Control);
            if(data == null || control == null) return;
            data.Columns.ToList().ForEach(column =>
            {
                var cellWidth = control.Width;
                if(double.IsNaN(cellWidth) || double.IsInfinity(cellWidth)) return;
                column.Width = cellWidth;
            });
        }
        public static void SetColumnActualWidth(DependencyObject element, double value)
        {
            element.SetValue(ColumnActualWidthProperty, value);
        }
        public static double GetColumnActualWidth(DependencyObject element)
        {
            return (double) element.GetValue(ColumnActualWidthProperty);
        }
    }
