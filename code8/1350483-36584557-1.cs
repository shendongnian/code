    public class ApplyAllCheckBoxBindingsInListBoxBehavior
    {
        public static ListBox GetListBox(DependencyObject obj)
        {
            return (ListBox)obj.GetValue(ListBoxProperty);
        }
        public static void SetListBox(DependencyObject obj, ListBox value)
        {
            obj.SetValue(ListBoxProperty, value);
        }
        // Using a DependencyProperty as the backing store for ListBox.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ListBoxProperty =
            DependencyProperty.RegisterAttached("ListBox", typeof(ListBox), typeof(ApplyBindingsBehavior), new PropertyMetadata(null, ListBoxChanged));
        private static void ListBoxChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Button button = d as Button;
            if (button == null)
                return;
            button.Click -= OnClick;
            button.Click += OnClick;
        }
        private static void OnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            ListBox lb = GetListBox(sender as Button);
            IEnumerable<CheckBox> allCBs = VisualHelper.FindVisualChildren<CheckBox>(lb);
            foreach (CheckBox checkBox in allCBs)
            {
                checkBox.GetBindingExpression(CheckBox.IsCheckedProperty).UpdateSource();
            }
        }
    }
