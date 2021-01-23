    public class RoutedEventTrigger : FrameworkElement
    {       
        RoutedEvent _routedEvent;
        public RoutedEvent RoutedEvent
        {
            get { return _routedEvent; }
            set { _routedEvent = value; }
        }
        private Action<object, RoutedEventArgs> handler;
        public Action<object, RoutedEventArgs> Handler
        {
            get { return handler; }
            set { handler = value; }
        }
        public static DataTemplate GetTemplate(DependencyObject obj)
        {
            return (DataTemplate)obj.GetValue(TemplateProperty);
        }
        public static void SetTemplate(DependencyObject obj, DataTemplate value)
        {
            obj.SetValue(TemplateProperty, value);
        }
        public static readonly DependencyProperty TemplateProperty =
            DependencyProperty.RegisterAttached("Template",
            typeof(DataTemplate),
            typeof(RoutedEventTrigger),
            new PropertyMetadata(default(DataTemplate), OnTemplateChanged));
        private static void OnTemplateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataTemplate dt = (DataTemplate)e.NewValue;
            if (dt != null)
            {
                dt.Seal();
                RoutedEventTrigger ih = (RoutedEventTrigger)dt.LoadContent();
                (d as FrameworkElement).AddHandler(ih.RoutedEvent, new RoutedEventHandler(ih.OnRoutedEvent));                
            }
        }
        void OnRoutedEvent(object sender, RoutedEventArgs args)
        {
            Handler.Invoke(sender, args);
        }
        
    } 
