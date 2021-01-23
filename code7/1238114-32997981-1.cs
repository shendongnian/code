    public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = MVVMList.Instance;
                Loaded += MainWindow_Loaded;
            }
    
            void MainWindow_Loaded(object sender, RoutedEventArgs e)
            {
                var x = new CreateWindow();
                x.Show();
            }
        }
