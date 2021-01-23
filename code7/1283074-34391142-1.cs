    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<string> listDiv;
        public ObservableCollection<string> ListDiv
        {
            get { return listDiv; }
            set
            {
                listDiv = value;
                OnNotifyPropertyChanged("ListDiv");
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            GetList();
        }
        private void GetList()
        {
            ListDiv = new ObservableCollection<string>();
            ListDiv.Add("1-10");
            ListDiv.Add("2-20"); 
            ListDiv.Add("3-30"); 
            ListDiv.Add("4-40");
            ListDiv.Add("5-50");
            ListDiv.Add("6-60");
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnNotifyPropertyChanged(string S)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(S));
        }
    }
