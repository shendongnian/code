     public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
       
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Check != null)
                Check(TextBox.Text);
        }
        public event Action<string> Check;
      
    }
