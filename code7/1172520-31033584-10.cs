    public partial class MainWindow : Window
    {
        public ObservableCollection<DupInfo> items { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            items = new ObservableCollection<DupInfo>();
            items.Add(new DupInfo() { BaseDirectory = "Directory1", CheckSum = 0xFF, FullName = "Info1", Size = 100 });
            items.Add(new DupInfo() { BaseDirectory = "Directory2", CheckSum = 0xFE, FullName = "Info2", Size = 150 });
            items.Add(new DupInfo() { BaseDirectory = "Directory2", CheckSum = 0xFD, FullName = "Info3", Size = 200 });
            this.DataContext = this;
        }
    }
