    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            MyTextBlock.Text = Enum.GetName(typeof(System.Windows.Input.Key), e.Key);
        }
    }
