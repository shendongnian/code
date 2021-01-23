    public static class SelectorHelper
    {
        public static readonly DependencyProperty IsItemSelectionEnabledProperty =
            DependencyProperty.RegisterAttached("IsItemSelectionEnabled", typeof(bool), typeof(SelectorHelper), new PropertyMetadata(true, IsItemSelectionEnabledChanged));
        public static void SetIsItemSelectionEnabled(DependencyObject dependencyObject, bool value)
        {
            dependencyObject.SetValue(IsItemSelectionEnabledProperty, value);
        }
        public static bool GetIsItemSelectionEnabled(DependencyObject dependencyObject)
        {
            return (bool)dependencyObject.GetValue(IsItemSelectionEnabledProperty);
        }
        private static void IsItemSelectionEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var frameworkElement = (FrameworkElement)d;
            var selectorItem = XamlTreeHelper.FindParent<SelectorItem>(frameworkElement);
            if (selectorItem != null)
            {
                selectorItem.IsEnabled = GetIsItemSelectionEnabled(frameworkElement);
            }
            else
            {
                frameworkElement.Loaded -= OnSelectableItemLoaded;
                frameworkElement.Loaded += OnSelectableItemLoaded;
            }
        }
        private static void OnSelectableItemLoaded(object sender, RoutedEventArgs e)
        {
            var frameworkElement = (FrameworkElement)sender;
            var selectorItem = FindParent<SelectorItem>(frameworkElement);
            if (selectorItem != null)
            {
                selectorItem.IsEnabled = GetIsItemSelectionEnabled(frameworkElement);
            }
        }
        private static T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            var currentObject = child;
            do
            {
                currentObject = VisualTreeHelper.GetParent(currentObject);
                var parent = currentObject as T;
                if (parent != null)
                {
                    return parent;
                }
            } while (currentObject != null);
            return null;
        }
    }
