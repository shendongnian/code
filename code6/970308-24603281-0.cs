     public MainWindow()
        {
            InitializeComponent();
            Data.Add(new ChartData() {Name=DateTime.Now,Value=200000 });
            win.DataContext = Data;
        }
        private ObservableCollection<ChartData> data;
        public ObservableCollection<ChartData> Data
        {
            get 
            { 
                if(data == null)
                {
                   return data = new ObservableCollection<ChartData>();
                }
                else
                return data; 
            }
            set 
            { 
                data = value;
                OnPropertyChanged("Data");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
