    namespace Hello_World
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            private MainViewModel MyViewModel;
    
    
            public MainWindow()
            {
                InitializeComponent();
                MyViewModel = new MainViewModel();
                
                // Here's where I'm setting the object to look at.
                DataContext = MyViewModel;
                // Now I don't need to access the textbox directly.
                MyViewModel.MyLabel = "Hello World";    
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                // Note: ICommand is a more advanced topic.
                MyViewModel.MyLabel = MyTextBox.Text;
            }
        }
    }
