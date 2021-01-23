    public partial class MyUserControl : UserControl
    {
        public static readonly DependencyProperty EventsProperty =
                                   DependencyProperty.Register("Events", 
                                       typeof(IEnumerable), 
                                       typeof(MyUserControl), 
                                       new PropertyMetadata(EventsPropertyChanged));
        private static void EventsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MyUserControl)d).EventsPropertyChanged(e);
        }
        private void EventsPropertyChanged(DependencyPropertyChangedEventArgs args)
        {
            var newCollection = args.NewValue as INotifyCollectionChanged;
            if (newCollection != null)
                newCollection.CollectionChanged += (s, e) => myTextBlock.GetBindingExpression(TextBlock.TextProperty).UpdateTarget();
        }
        public IEnumerable Events
        {
            get { return (IEnumerable)GetValue(EventsProperty); }
            set { SetValue(EventsProperty, value); }
        }
    }
