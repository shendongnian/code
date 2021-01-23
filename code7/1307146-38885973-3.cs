    public static class ListBoxAutoscrollBehavior
    {
        public static readonly DependencyProperty AutoscrollProperty = DependencyProperty.RegisterAttached(
            "Autoscroll", typeof (bool), typeof (ListBoxAutoscrollBehavior),
            new PropertyMetadata(default(bool), AutoscrollChangedCallback));
        private static readonly Dictionary<ListBox, SelectionChangedEventHandler> handlersDict =
            new Dictionary<ListBox, SelectionChangedEventHandler>();
        private static void AutoscrollChangedCallback(DependencyObject dependencyObject,
            DependencyPropertyChangedEventArgs args)
        {
            var listBox = dependencyObject as ListBox;
            if (listBox == null)
            {
                throw new InvalidOperationException("Dependency object is not ListBox.");
            }
            if ((bool) args.NewValue)
            {
                Subscribe(listBox);
                listBox.Unloaded += ListBoxOnUnloaded;
                listBox.Loaded += ListBoxOnLoaded;
            }
            else
            {
                Unsubscribe(listBox);
                listBox.Unloaded -= ListBoxOnUnloaded;
                listBox.Loaded -= ListBoxOnLoaded;
            }
        }
        private static void Subscribe(ListBox listBox)
        {
            if (handlersDict.ContainsKey(listBox))
            {
                return;
            }
            var handler = new SelectionChangedEventHandler((sender, eventArgs) => ScrollToSelect(listBox));
            handlersDict.Add(listBox, handler);
            listBox.SelectionChanged += handler;
            ScrollToSelect(listBox);
        }
        private static void Unsubscribe(ListBox listBox)
        {
            SelectionChangedEventHandler handler;
            handlersDict.TryGetValue(listBox, out handler);
            if (handler == null)
            {
                return;
            }
            listBox.SelectionChanged -= handler;
            handlersDict.Remove(listBox);
        }
        private static void ListBoxOnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            var listBox = (ListBox) sender;
            if (GetAutoscroll(listBox))
            {
                Subscribe(listBox);
            }
        }
        private static void ListBoxOnUnloaded(object sender, RoutedEventArgs routedEventArgs)
        {
            var listBox = (ListBox) sender;
            if (GetAutoscroll(listBox))
            {
                Unsubscribe(listBox);
            }
        }
        private static void ScrollToSelect(ListBox datagrid)
        {
            if (datagrid.Items.Count == 0)
            {
                return;
            }
            if (datagrid.SelectedItem == null)
            {
                return;
            }
            datagrid.ScrollIntoView(datagrid.SelectedItem);
        }
        public static void SetAutoscroll(DependencyObject element, bool value)
        {
            element.SetValue(AutoscrollProperty, value);
        }
        public static bool GetAutoscroll(DependencyObject element)
        {
            return (bool) element.GetValue(AutoscrollProperty);
        }
    }
