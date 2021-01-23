    public partial class MainWindow : Window
    {
        private Dialog m_Dialog;
        public MainWindow()
        {
            InitializeComponent();
            m_Dialog = new Dialog();
            this.MouseDoubleClick += onCloseDialog;
        }
        private void onCloseDialog(object sender, MouseButtonEventArgs e)
        {
            m_Dialog.Hide();
        }
        private void onButton(object sender, RoutedEventArgs e)
        {
            m_Dialog.Show();
        }
    }
