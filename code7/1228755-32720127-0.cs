    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        #endregion
        private bool _isRadioChecked;
        public bool IsRadioChecked
        {
            get
            {
                return _isRadioChecked;
            }
            set
            {
                _isRadioChecked = value;
                OnPropertyChanged("IsRadioChecked");
            }
        }
    }
