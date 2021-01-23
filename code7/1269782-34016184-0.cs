    public class ContentControlWithNotification : ContentControl
    {
        static ContentControlWithNotification()
        {
            ContentProperty.OverrideMetadata(typeof(ContentControlWithNotification), new FrameworkPropertyMetadata(OnContentChanged));
        }
    
        private static void OnContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var mcc = d as ContentControlWithNotification;
    
            if (mcc.ContentChanged != null)
            {
                var args = new DependencyPropertyChangedEventArgs(ContentProperty, e.OldValue, e.NewValue);
                mcc.ContentChanged(mcc, args);
            }
        }
    
        public event DependencyPropertyChangedEventHandler ContentChanged;
    }
