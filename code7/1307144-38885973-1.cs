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
        private static void Subscribe(ListBox dataGrid)
        {
            if (handlersDict.ContainsKey(dataGrid))
            {
                return;
            }
            var handler = new SelectionChangedEventHandler((sender, eventArgs) => ScrollToSelect(dataGrid));
            handlersDict.Add(dataGrid, handler);
            dataGrid.SelectionChanged += handler;
            ScrollToSelect(dataGrid);
        }
        private static void Unsubscribe(ListBox dataGrid)
        {
            SelectionChangedEventHandler handler;
            handlersDict.TryGetValue(dataGrid, out handler);
            if (handler == null)
            {
                return;
            }
            dataGrid.SelectionChanged -= handler;
            handlersDict.Remove(dataGrid);
        }
        private static void ListBoxOnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            var dataGrid = (ListBox) sender;
            if (GetAutoscroll(dataGrid))
            {
                Subscribe(dataGrid);
            }
        }
        private static void ListBoxOnUnloaded(object sender, RoutedEventArgs routedEventArgs)
        {
            var dataGrid = (ListBox) sender;
            if (GetAutoscroll(dataGrid))
            {
                Unsubscribe(dataGrid);
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
