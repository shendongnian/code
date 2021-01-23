    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Model = new Model();
            InitializeComponent();
            this.DataContext = Model;
        }
        public Model Model { get; set; }
        private void CustonDatagrid_OnAddButtonClick(object sender, RoutedEventArgs e)
        {
            Model.AddElement();
        }
    }
