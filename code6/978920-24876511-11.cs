    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AddHandler(ChildControl.PreviewTestEvent,
              new RoutedEventHandler((s, e) => Console.WriteLine("Parent handler")));
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // raise the child event from the main window
            childCtrl.RaiseEvent(new RoutedEventArgs(ChildControl.PreviewTestEvent));
        }
    }
