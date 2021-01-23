    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaiseProperty(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        private string status = "notRead";
        public string Status
        {
            get { return status; }
            set { status = value; RaiseProperty(nameof(Status)); }
        }
        public MainPage()
        {
            this.InitializeComponent();
            DataContext = this;
        }
        private void Button_Click(object sender, RoutedEventArgs e) => Status = "read";
    }
