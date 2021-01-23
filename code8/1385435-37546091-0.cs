    public class EnterKeyTraversal
    {
        public static bool GetIsEnabled(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsEnabledProperty);
        }
        public static void SetIsEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(IsEnabledProperty, value);
        }
        static void ue_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var ue = e.OriginalSource as FrameworkElement;
            DependencyObject dep = ue;
            while (!(dep == null || dep is DataGrid))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }
            DependencyObject combo = ue;
            while (!(combo == null || combo is ComboBox))
            {
                combo = VisualTreeHelper.GetParent(combo);
            }
            if (!(ue is Button || ue is ListBoxItem || dep is DataGrid || (combo is ComboBox && ((ComboBox)combo).Tag.ToString() == "IgnoreEnterKeyTraversal")))
            {
                if (e.Key == Key.Enter)
                {
                    if (!(ue.Tag != null && ue.Tag.ToString() == "IgnoreEnterKeyTraversal"))
                    {
                        e.Handled = true;
                        ue.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                    }
                }
            }
        }
        private static void ue_Unloaded(object sender, RoutedEventArgs e)
        {
            var ue = sender as FrameworkElement;
            if (ue == null) return;
            ue.Unloaded -= ue_Unloaded;
            ue.PreviewKeyDown -= ue_PreviewKeyDown;
        }
        public static readonly DependencyProperty IsEnabledProperty =
            DependencyProperty.RegisterAttached("IsEnabled", typeof(bool),
            typeof(EnterKeyTraversal), new UIPropertyMetadata(false, IsEnabledChanged));
        static void IsEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ue = d as FrameworkElement;
            if (ue == null) return;
            if ((bool)e.NewValue)
            {
                ue.Unloaded += ue_Unloaded;
                ue.PreviewKeyDown += ue_PreviewKeyDown;
            }
            else
            {
                ue.PreviewKeyDown -= ue_PreviewKeyDown;
            }
        }
    }
