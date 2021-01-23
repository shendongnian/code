    public class MainViewModel : INotifyPropertyChanged
    {
        private string _selectedItemsOutput;
    
        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact> { new Contact() { Id = 1, Name = "Foo" }, new Contact() { Id = 2, Name = "Bar" } };
    
        public ICommand GoCommand => new RelayCommand(Go);
    
        public string SelectedItemsOutput
        {
            get { return _selectedItemsOutput; }
            set
            {
                if (value == _selectedItemsOutput) return;
                _selectedItemsOutput = value;
                OnPropertyChanged();
            }
        }
    
        void Go()
        {
            SelectedItemsOutput = string.Join(", ", Contacts.Where(x => x.IsSelected).Select(x => x.Name));
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    }
    
    public class Contact : INotifyPropertyChanged
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
    
        public override string ToString()
        {
            return Name;
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    }
    
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
