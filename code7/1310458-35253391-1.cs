    public class DataGridAttached
    {
        public static readonly DependencyProperty SetDataGridDataContextToTagProperty = DependencyProperty.RegisterAttached(
            "SetDataGridDataContextToTag", typeof (bool), typeof (DataGridAttached), new PropertyMetadata(default(bool), SetParentDataContextToTagPropertyChangedCallback));
        public static void SetSetDataGridDataContextToTag(DependencyObject element, bool value)
        {
            element.SetValue(SetDataGridDataContextToTagProperty, value);
        }
        public static bool GetSetDataGridDataContextToTag(DependencyObject element)
        {
            return (bool) element.GetValue(SetDataGridDataContextToTagProperty);
        }
        private static void SetParentDataContextToTagPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            PerformDataContextToTagAssignment(dependencyObject as FrameworkElement, (bool)args.NewValue);
        }
        private static void PerformDataContextToTagAssignment(FrameworkElement sender, bool isAttaching)
        {
            var control = sender;
            if (control == null) return;
            if (isAttaching == false)
            {
                control.Tag = null;
            }
            else
            {
                var dataGrid = control.FindParent<DataGrid>();
                if (dataGrid == null) return;
                control.Tag = dataGrid.DataContext;
            }
        }
    }
