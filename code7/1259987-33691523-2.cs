    public partial class ConfigSetting : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
       
        private string lbIsVisible;
        public string LbIsVisible
        {
            get { return lbIsVisible; }
            set
            {
                if (lbIsVisible != value)
                {
                    lbIsVisible = value;
                    OnPropertyChanged("LbIsVisible");
                }
            }
        }
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public ConfigSetting()
        {
            InitializeComponent();
            LbIsVisible = "Hidden";
            DataContext = this;
        }        
        private void chkSelectVessel_Checked(object sender, RoutedEventArgs e)
        {
            LbIsVisible = "Visible";
        }
        private void ChkSelectVessel_OnUnchecked(object sender, RoutedEventArgs e)
        {
            LbIsVisible = "Hidden";
        }
    }
