    public class MainViewModel
    {
        public ObservableCollection<TestItem> Items { get; set; } = new ObservableCollection<TestItem> { new TestItem() { Id = 1, Name = "Foo" }, new TestItem() { Id = 2, Name = "Bar" } };
    
        public ICommand GoCommand => new DelegateCommand(Go);
    
        void Go()
        {
            MessageBox.Show(string.Join(Environment.NewLine, Items.Where(x => x.IsSelected).Select(x => x.Name)));
        }
    }
    
    public class TestItem : INotifyPropertyChanged
    {
        private bool _isSelected;
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value == _isSelected) return;
                _isSelected = value;
                OnPropertyChanged();
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
