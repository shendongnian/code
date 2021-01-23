    public class TabControlHeaderWidthWatcher
    {
        private static TabControl m_tabControl;
    
        public static readonly DependencyProperty WatchHeadersWidthProperty = DependencyProperty.RegisterAttached(
            "WatchHeadersWidth", typeof (bool), typeof (TabControlHeaderWidthWatcher), new PropertyMetadata(default(bool), PropertyChangedCallback));
    
        public static void SetWatchHeadersWidth(DependencyObject element, bool value)
        {
            element.SetValue(WatchHeadersWidthProperty, value);
        }
    
        public static bool GetWatchHeadersWidth(DependencyObject element)
        {
            return (bool)element.GetValue(WatchHeadersWidthProperty);
        }
    
        public static readonly DependencyProperty TotalHeadersWidthProperty = DependencyProperty.RegisterAttached(
            "TotalHeadersWidth", typeof (double), typeof (TabControlHeaderWidthWatcher), new PropertyMetadata(default(double)));
    
        public static void SetTotalHeadersWidth(DependencyObject element, double value)
        {
            element.SetValue(TotalHeadersWidthProperty, value);
        }
    
        public static double GetTotalHeadersWidth(DependencyObject element)
        {
            return (double) element.GetValue(TotalHeadersWidthProperty);
        }
    
        private static void PropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            m_tabControl = dependencyObject as TabControl;
            if (m_tabControl == null) return;
    
            ((INotifyCollectionChanged)m_tabControl.Items).CollectionChanged += CollectionChanged;
        }
    
        private static void CollectionChanged(object sender, EventArgs eventArgs)
        {
            foreach (var item in m_tabControl.Items)
            {
                var tabItem = item as TabItem;
                if (tabItem == null) continue;
                
                // Unsubscribe first in case it was there previously
                tabItem.SizeChanged -= TabItemOnSizeChanged;
                tabItem.SizeChanged += TabItemOnSizeChanged;
            }
        }
    
        private static void TabItemOnSizeChanged(object sender, SizeChangedEventArgs sizeChangedEventArgs)
        {
            var totalWidth = 0.0;
            foreach (var item in m_tabControl.Items)
            {
                var tabItem = item as TabItem;
                if (tabItem == null) continue;
    
                totalWidth += tabItem.ActualWidth;
            }
    
            // When more than one row of tabs, the width of the TabControl is used
            var actualWidth = totalWidth > m_tabControl.ActualWidth ? m_tabControl.ActualWidth : totalWidth;
            SetTotalHeadersWidth(m_tabControl, actualWidth);
        }
    }
