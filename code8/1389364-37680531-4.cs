    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.MyControls = new ObservableCollection<Control>();
            this.DataContext = this;
            InitializeComponent();
        }
    
        public ObservableCollection<Control> MyControls { get; set; }
    
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            this.MyControls.Add(new Button() { Content = "New Button" });
        }
    }
