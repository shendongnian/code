    public partial class MainWindow : Window
    {
        public ObservableCollection<int> numbers { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            numbers = new ObservableCollection<int>();
            this.DataContext = this;
        }
        private void btnAddNumber_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbNewNumber.Text))
            {
                numbers.Add(int.Parse(tbNewNumber.Text));
            }
        }
    }
