    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    
        private void Border_Loaded(object sender, RoutedEventArgs e)
        {
            Border root = (Border)sender;
            ContentPresenter presenter = (ContentPresenter)root.TemplatedParent;
            presenter.HorizontalAlignment = HorizontalAlignment.Stretch;
        }
    }
