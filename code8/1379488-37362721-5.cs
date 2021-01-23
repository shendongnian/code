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
                
                // Here's where I'm setting the object to look at.
                MyLabel.DataContext = MyModel;
                // Now I don't need to access the textbox directly.
                MyModel.MyLabel = "Hello World";
    
    
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                MyModel.MyLabel = MyTextBox.Text;
            }
    
            
        }
    }
