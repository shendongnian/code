    public partial class MainWindow : Window
    {
        public ObservableCollection<int> Test { get; set; }
        public MainWindow()
        {
            Test = new ObservableCollection<int>();
            InitializeComponent();
            DataContext = this;
            Test.Add(1);
            Test.Add(123232);
        }
    }
