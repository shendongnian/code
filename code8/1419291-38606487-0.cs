    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public ImageList list 
        {
            get { return (ImageList)DataContext; }
        }
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            list.Next();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            list.Back();
        }
    }
