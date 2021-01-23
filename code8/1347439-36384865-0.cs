    public class MyContentControl : ContentControl
    {
        public static readonly RoutedEvent ContentChangedEvent 
            = EventManager.RegisterRoutedEvent(
                "ContentChanged",
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler), 
                typeof(MyContentControl));
        public event RoutedEventHandler ContentChanged
        {
            add { AddHandler(ContentChangedEvent, value); }
            remove { RemoveHandler(ContentChangedEvent, value); }
        }
        protected override void OnContentChanged(object oldContent, object newContent)
        {
            base.OnContentChanged(oldContent, newContent);
            RaiseEvent(new RoutedEventArgs(ContentChangedEvent, this));
        }
    }
