    /// <summary>
    /// Interaction logic for MyInputDialog.xaml
    /// </summary>
    public partial class MyInputDialog : Window
    {
        public MyInputDialog()
        {
            InitializeComponent();
        }
        private void bOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
        private void bCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
