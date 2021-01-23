    public partial class MainWindow : Window
    {
        public ObservableCollection<DupInfo> items { get; set; }
        List<DupInfo> initialList { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            items = new ObservableCollection<DupInfo>();
            initialList = new List<DupInfo>();
            initialList.Add(new DupInfo() { BaseDirectory = "Directory1", CheckSum = 0xFF, FullName = "Info1", Size = 100 });
            initialList.Add(new DupInfo() { BaseDirectory = "Directory2", CheckSum = 0xFE, FullName = "Info2", Size = 150 });
            initialList.Add(new DupInfo() { BaseDirectory = "Directory2", CheckSum = 0xFD, FullName = "Info3", Size = 200 });
            items.AddRange(initialList);
            this.DataContext = this;
        }
    }
    public static class ExtensionMethods
    {
        public static void AddRange(this ObservableCollection<DupInfo> value, List<DupInfo> list)
        {
            foreach (var dup in list)
                value.Add(dup);
        }
    }
