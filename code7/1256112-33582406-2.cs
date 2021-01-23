    public class BindingHelper
    {
        public static readonly DependencyProperty GridColumnBindingPathProperty =
            DependencyProperty.RegisterAttached(
                "GridColumnBindingPath", typeof(string), typeof(BindingHelper),
                new PropertyMetadata(null, GridBindingPathPropertyChanged));
        public static readonly DependencyProperty GridRowBindingPathProperty =
            DependencyProperty.RegisterAttached(
                "GridRowBindingPath", typeof(string), typeof(BindingHelper),
                new PropertyMetadata(null, GridBindingPathPropertyChanged));
        public static string GetGridColumnBindingPath(DependencyObject obj)
        {
            return (string)obj.GetValue(GridColumnBindingPathProperty);
        }
        public static void SetGridColumnBindingPath(DependencyObject obj, string value)
        {
            obj.SetValue(GridColumnBindingPathProperty, value);
        }
        public static string GetGridRowBindingPath(DependencyObject obj)
        {
            return (string)obj.GetValue(GridRowBindingPathProperty);
        }
        public static void SetGridRowBindingPath(DependencyObject obj, string value)
        {
            obj.SetValue(GridRowBindingPathProperty, value);
        }
        private static void GridBindingPathPropertyChanged(
            DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var propertyPath = e.NewValue as string;
            if (propertyPath != null)
            {
                var gridProperty =
                    e.Property == GridColumnBindingPathProperty
                    ? Grid.ColumnProperty
                    : Grid.RowProperty;
                BindingOperations.SetBinding(
                    obj,
                    gridProperty,
                    new Binding { Path = new PropertyPath(propertyPath) });
            }
        }
    }
