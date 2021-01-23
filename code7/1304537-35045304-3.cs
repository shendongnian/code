    public class Window1 : Window
    {
        private readonly MainWindow _owner;
        // The only constructor of Window1 class
        public Window1(MainWindow owner)
        {
            InitializeComponent();
            _owner = owner;
        }
        
        private void button_Click(object sender, RoutedEventArgs e)
        {
            _owner.TbW1.Text = "Sword1";
        }
    }
    public class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void button_Click(object sender, RoutedEventArgs e)
        {
            // create new instance of Window1 and pass current window as a constructor parameter
            var win1 = new Window1(this);
            win1.Show();
        }
    }
