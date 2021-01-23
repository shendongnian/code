    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AddHandler(ChildControl.PreviewEvent, 
              new RoutedEventHandler((s, e) => Console.WriteLine("Parent handler")));
        }
    }
