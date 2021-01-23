    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media;
    
    public class CustomListView : ListView
    {
        private object _header;
        private object _footer;
    
        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
    
            Loaded += OnLoaded;
        }
    
        private void OnLoaded(object sender, RoutedEventArgs args)
        {
            Loaded -= OnLoaded;
            var scrollViewer = FindChild<ScrollViewer>(this);
            if(scrollViewer == null) return;
    
            scrollViewer.ViewChanged += ScrollViewerOnViewChanged;
        }
    
        private void ScrollViewerOnViewChanged(object sender, ScrollViewerViewChangedEventArgs args)
        {
            if (Header != null)
            {
                _header = Header;
                Header = null;
            }
    
            if (Footer != null)
            {
                _footer = Footer;
                Footer = null;
            }
    
            // TODO start a timer which will restore the header and footer after a specified amount of time when this event is not fired
        }
    
        private static T FindChild<T>(DependencyObject parent) where T : DependencyObject
        {
            var childCount = VisualTreeHelper.GetChildrenCount(parent);
            for (var i = 0; i < childCount; i++)
            {
                var elt = VisualTreeHelper.GetChild(parent, i);
                if (elt is T) return (T)elt;
                var result = FindChild<T>(elt);
                if (result != null) return result;
            }
    
            return null;
        }
    }
