        public partial class MainWindow : Window, INotifyPropertyChanged
        {
            public MainWindow()
            {
                InitializeComponent();
    
                DataContext = this;
                
            }
    
            public string _contentMsg;
            public string ContentMsg
            {
                get { return _contentMsg; }
                set 
                { 
                    _contentMsg = value;
                    RaisePropertyChanged("ContentMsg");
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            private void RaisePropertyChanged(string propName)
            {
                if(PropertyChanged !=null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propName));
                }
            }
