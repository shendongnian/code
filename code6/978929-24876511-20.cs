    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AddHandler(ChildControl.PreviewEvent,
              new RoutedEventHandler((s, e) => Console.WriteLine("Parent handler")));
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // raise the child event from the main window
            childCtrl.RaiseEvent(new RoutedEventArgs(ChildControl.PreviewEvent));
        }
    }
    // child control handles its routed event, but doesn't know who triggered it
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
    }
