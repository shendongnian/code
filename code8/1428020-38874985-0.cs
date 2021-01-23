    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        public int Rows { get; private set; } = 3;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        void ListBox_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Rows = ((ListBox)sender).ActualHeight > 700 ? 4 : 3;
            OnPropertyChanged(nameof(Rows));
        }
    }
