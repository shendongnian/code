    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();  
          
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddWindow popup = new AddWindow();
            popup.Check += popup_Check;
            popup.Show();
        
        }
        void popup_Check(string obj)
        {
            ListBox.Items.Add(obj);
        }
    }
