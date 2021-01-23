    public class MainViewModel
    {
        public ObservableCollection<TestItem> Items { get; set; } = new ObservableCollection<TestItem> { new TestItem() { Id = 1, Name = "Foo" }, new TestItem() { Id = 2, Name = "Bar" } };
            
        public ICommand GoCommand => new DelegateCommand<TestItem>(Go);
    
        void Go(TestItem selected)
        {
            if (selected != null)
                MessageBox.Show(selected.Name);
        }
    }
    
    public class TestItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    
        public override string ToString()
        {
            return Name;
        }
    }
    
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
    
            DataContext = new MainViewModel();
        }
    }
