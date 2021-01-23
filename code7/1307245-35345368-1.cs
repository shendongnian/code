    public class Attached
    {
        public static readonly DependencyProperty AreChildrenEnabledProperty = DependencyProperty.RegisterAttached("AreChildrenEnabled", typeof (bool), typeof (Attached), new PropertyMetadata(default(bool), AreChildrenEnabledPropertyChangedCallback));
        private static void AreChildrenEnabledPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            var val = (bool) args.NewValue;
            if (val == false)
            {
                var visual = dependencyObject as FrameworkElement;
                if (visual == null) return;
                visual.Loaded -= VisualOnLoaded;
                visual.Unloaded -= VisualOnUnloaded;
            }
            else
            {
                var visual = dependencyObject as FrameworkElement;
                if(visual == null) return;
                visual.Loaded += VisualOnLoaded;
                visual.Unloaded += VisualOnUnloaded;
            }
        }
        private static void VisualOnUnloaded(object sender, RoutedEventArgs e)
        {
            var visual = sender as FrameworkElement;
            if (visual == null) return;
            visual.Loaded -= VisualOnLoaded;
        }
        private static void VisualOnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            var visual = sender as FrameworkElement;
            if (visual == null) return;
            var list = visual.GetAllVisualChildren();
            Debug.WriteLine("children count on loading: {0}", list.Count);
            var actionOnChildrenLoading = GetActionOnEachLoadedVisualChild(visual);
            if(actionOnChildrenLoading == null) return;
            list.ForEach(o =>
            {
                var combo = o as ComboBox;
                if (combo != null)
                {
                    combo.IsEnabled = false;
                }
                var button = o as Button;
                if (button != null)
                {
                    button.IsEnabled = false;
                }
                var textBlock = o as TextBlock;
                if (textBlock != null)
                {
                    textBlock.IsEnabled = false;
                }
                var cb = o as CheckBox;
                if (cb != null)
                {
                    cb.IsEnabled = false;
                }
                var textBox = o as TextBox;
                if (textBox == null) return;
                textBox.IsEnabled = true;
                textBox.IsReadOnly = true;
            });
        }
        public static readonly DependencyProperty ActionOnEachLoadedVisualChildProperty = DependencyProperty.RegisterAttached(
            "ActionOnEachLoadedVisualChild", typeof (Action<DependencyObject>), typeof (Attached), new PropertyMetadata(default(Action<DependencyObject>)));
        public static void SetActionOnEachLoadedVisualChild(DependencyObject element, Action<DependencyObject> value)
        {
            element.SetValue(ActionOnEachLoadedVisualChildProperty, value);
        }
        public static Action<DependencyObject> GetActionOnEachLoadedVisualChild(DependencyObject element)
        {
            return (Action<DependencyObject>) element.GetValue(ActionOnEachLoadedVisualChildProperty);
        }
        public static bool GetAreChildrenEnabled(UIElement element)
        {
            return (bool) element.GetValue(AreChildrenEnabledProperty);
        }
        public static void SetAreChildrenEnabled(UIElement element, bool value)
        {
            element.SetValue(AreChildrenEnabledProperty, value);
        }
    }
