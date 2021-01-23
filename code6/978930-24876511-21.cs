    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            childCtrl.DoSomething(this, "MainWindow just sent you an event");
        }
    }
    public partial class ChildControl : UserControl
    {
        public ChildControl()
        {
            InitializeComponent();
        }
        public void DoSomething(UIElement sender, string message)
        {
            Console.WriteLine(sender.ToString() + ": " + message);
        }
    }
    
