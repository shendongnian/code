     public partial class MainWindow : Window
    {
        public ProductionManager myManager;
        public MainWindow()
        {
            InitializeComponent();
            myManager = new ProductionManager();
            window = this;
        }
        internal static MainWindow window;
        public string myString
        {
            get { return myTextBox.Text; }
              //this is where you change the text of your text box
            set { Dispatcher.Invoke(new Action(() => { myTextBox.Text = value; })); }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            myManager.DoSomething("Hello world");
        }
    }
