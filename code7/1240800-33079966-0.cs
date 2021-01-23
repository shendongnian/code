    public class CheckBoxBehavior
    {
        public static bool GetDisableAutoCheck(DependencyObject obj) => (bool)obj.GetValue(DisableAutoCheckProperty);
        public static void SetDisableAutoCheck(DependencyObject obj, bool value) => obj.SetValue(DisableAutoCheckProperty, value);
        public static readonly DependencyProperty DisableAutoCheckProperty =
            DependencyProperty.RegisterAttached("DisableAutoCheck", typeof(bool),
            typeof(CheckBoxBehavior), new PropertyMetadata(false, (d, e) =>
            {
                var checkBox = d as CheckBox;
                if (checkBox == null)
                    throw new ArgumentException("Only used with CheckBox");
                if ((bool)e.NewValue)
                    checkBox.Click += DisableAutoCheck_Click;
                else
                    checkBox.Click -= DisableAutoCheck_Click;
            }));
        private static void DisableAutoCheck_Click(object sender, RoutedEventArgs e) =>
            ((CheckBox)sender).IsChecked = !((CheckBox)sender).IsChecked;
    }
