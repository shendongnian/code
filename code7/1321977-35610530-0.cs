    public partial class MainWindow : Window
    {
        private string _selectedItem;
        private ObservableCollection<string> ServerNames;
        private string fileLocation = @"C:\Temp\ServerNames.txt";
        public MainWindow()
        {
           ServerNames = new ObservableCollection<string>();
            if (File.Exists(fileLocation))
            {
                var list = File.ReadAllLines(fileLocation).ToList();
                list.ForEach(ServerNames.Add);
            }
            DataContext = this;
            InitializeComponent();
        }
        public IEnumerable Items => ServerNames;
        public string SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }
        public string NewItem
        {
            set
            {
                if (SelectedItem != null)
                {
                    return;
                }
                if (!string.IsNullOrEmpty(value))
                {
                    ServerNames.Add(value);
                    SelectedItem = value;
                }
            }
        }
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (!File.Exists(fileLocation))
            {
                File.Create(fileLocation);
            }
            File.WriteAllLines(fileLocation, ServerNames);
        }
    }
