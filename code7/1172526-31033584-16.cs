    public partial class MainWindow : Window
    {
        public ObservableCollection<DupInfo> items
        {
            get { return (ObservableCollection<DupInfo>)GetValue(itemsProperty); }
            set { SetValue(itemsProperty, value); }
        }
        // Using a DependencyProperty as the backing store for items.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty itemsProperty =
            DependencyProperty.Register("items", typeof(ObservableCollection<DupInfo>), typeof(MainWindow), new PropertyMetadata(null));
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
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            foreach (var dup in items.ToList())
            {
                if (dup.ToDelete)
                {
                    items.Remove(dup);
                }
            }
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
