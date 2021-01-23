    // ChildControl is the event source
    public partial class ChildControl : UserControl
    {
        public readonly static RoutedEvent PreviewEvent = 
            EventManager.RegisterRoutedEvent(
                "PreviewEvent",
                RoutingStrategy.Tunnel,
                typeof(RoutedEventHandler),
                typeof(ChildControl));
        
        public ChildControl()
        {
            InitializeComponent();
            AddHandler(PreviewEvent, 
              new RoutedEventHandler((s, e) => Console.WriteLine("Child handler")));
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // make this control the source element for tunneling
            this.RaiseEvent(new RoutedEventArgs(PreviewEvent));
        }
    }
