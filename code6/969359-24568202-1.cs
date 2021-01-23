    namespace CSharpWPF
    {
        public class NavigationHelper : DependencyObject
        {
            public static bool GetIsEnabled(DependencyObject obj)
            {
                return (bool)obj.GetValue(IsEnabledProperty);
            }
            public static void SetIsEnabled(DependencyObject obj, bool value)
            {
                obj.SetValue(IsEnabledProperty, value);
            }
            // Using a DependencyProperty as the backing store for IsEnabled.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty IsEnabledProperty =
                DependencyProperty.RegisterAttached("IsEnabled", typeof(bool), typeof(NavigationHelper), new PropertyMetadata(false, OnIsEnabledChanged));
            private static void OnIsEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                Selector selector = d as Selector;
                if ((bool)e.NewValue)
                    selector.PreviewKeyDown += selector_PreviewKeyDown;
                else
                    selector.PreviewKeyDown -= selector_PreviewKeyDown;
            }
            static void selector_PreviewKeyDown(object sender, KeyEventArgs e)
            {
                Selector selector = sender as Selector;
                if (selector.Items.Count == 0)
                    return;
                ListViewItem itemToSelect = null;
                if (e.Key == Key.Up && selector.SelectedIndex == 0)
                {
                    itemToSelect = selector.ItemContainerGenerator.ContainerFromIndex(selector.Items.Count - 1) as ListViewItem;
                }
                else if (e.Key == Key.Down && selector.SelectedIndex == selector.Items.Count - 1)
                {
                    itemToSelect = selector.ItemContainerGenerator.ContainerFromIndex(0) as ListViewItem;
                }
                if (itemToSelect != null)
                {
                    selector.SelectedItem = itemToSelect;
                    itemToSelect.Focus();
                    e.Handled = true;
                }
            }
        }
    }
