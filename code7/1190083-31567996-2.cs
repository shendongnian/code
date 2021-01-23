        public partial class MainWindow : Window
    {
        // create some view model
        SomeModel model = new SomeModel();
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Loaded -= MainWindow_Loaded;
            // set context
            this.DataContext = model;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // change property in view model (not image)
            if (model.Flag)
                model.Flag = false;
            else
                model.Flag = true;
        }        
    }
