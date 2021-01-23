    // this uses the existing Button.PreviewMouseUpEvent tunneled event
    public partial class ChildControl : UserControl
    {
        public ChildControl()
        {
            InitializeComponent();
            AddHandler(Button.PreviewMouseUpEvent, 
              new RoutedEventHandler((s, e) => Console.WriteLine("Child handler")));
        }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AddHandler(Button.PreviewMouseUpEvent, 
              new RoutedEventHandler((s, e) => Console.WriteLine("Parent handler")));
        }
    }
