        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                DataContext = this;
    
                FillList();
            }
    
            private void FillList()
            {
                WorkingItems.Add(new WorkingItem {DateTime = DateTime.Today, Worker = "Chef"});
                WorkingItems.Add(new WorkingItem {DateTime = DateTime.Today, Worker = "Waiter"});
                WorkingItems.Add(new WorkingItem {DateTime = DateTime.Today.AddDays(1), Worker = "Chef"});
                WorkingItems.Add(new WorkingItem {DateTime = DateTime.Today.AddDays(2), Worker = "Other"});
                WorkingItems.Add(new WorkingItem {DateTime = DateTime.Today.AddDays(3), Worker = "Nobody"});
            }
    
            public ObservableCollection<WorkingItem> WorkingItems { get; set; } = new ObservableCollection<WorkingItem>();
        }
