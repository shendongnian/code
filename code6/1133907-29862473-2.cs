    public partial class MainWindow : Window {
        private ModelClass model = new ModelClass();
        public MainWindow() {
            InitializeComponent();
            this.customUserControl.DataContext = this.model;
        }
        private void button_Click(object sender, RoutedEventArgs e) {
            this.model.DayOfWeek = DayOfWeek.Sunday;
        }
    }
