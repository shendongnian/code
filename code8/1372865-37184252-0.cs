    public class WebViewSizeBehavior : DependencyObject, IBehavior
    {
        public DependencyObject AssociatedObject { get; private set; }
        
        public void Attach(DependencyObject associatedObject)
        {
            var control = associatedObject as WebView;
            if (control == null)
                throw new ArgumentException(
                    "WebViewSizeBehavior can be attached only to WebView.");
            AssociatedObject = associatedObject;
            control.LoadCompleted += Control_LoadCompleted;
        }
        private void Control_LoadCompleted(object sender, Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            var control = (WebView) AssociatedObject;
            var resizeTask = control.ResizeToContent();
        }
        public void Detach()
        {
            var control = (WebView) AssociatedObject;
            control.LoadCompleted -= Control_LoadCompleted;
            AssociatedObject = null;
        }
    }
