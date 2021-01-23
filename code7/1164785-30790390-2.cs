    public partial class MainWindow : Window
    {
        public ObservableCollection<int> numbers { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            numbers = new ObservableCollection<int>();
            IEnumerable<int> generatedNumbers = Enumerable.Range(1, 20).Select(x => x);
            foreach (int nr in generatedNumbers)
            {
                numbers.Add(nr);
            }
            this.DataContext = this;
        }
    }
