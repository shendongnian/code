    namespace Hello_World
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            private ModelView MyModel;
    
    
            public MainWindow()
            {
                InitializeComponent();
                MyModel = new ModelView();
    
                MyLabel.DataContext = MyModel;
    
                MyModel.MyLabel = "Hello World";
    
    
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                MyModel.MyLabel = MyTextBox.Text;
            }
    
            
        }
    }
