    public partial class PageOne : Page, IPageInterface, INotifyPropertyChanged
    {
        private string _astr;
        public String aStr
        {
            get { return _astr; }
            set { _astr = value; OnPropertyChanged(); }
        }
        public Page1()
        {
            InitializeComponent();
        }
        public void Start()
        {
            aStr = "Test";
        }
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
