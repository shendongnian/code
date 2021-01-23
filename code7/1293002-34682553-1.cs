	public partial class MainWindow : Window, INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        protected void OnPropertyChanged(string property)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        #endregion
        private ObservableCollection<animalTypes1> _source1 = new ObservableCollection<animalTypes1> {
            new animalTypes1() { type1name = "Mammals" } };
        public ObservableCollection<animalTypes1> Source1
        {
            get { return _source1; }
        }
        private ObservableCollection<animalTypes2> _source2 = new ObservableCollection<animalTypes2> {
            new animalTypes2() { type2name = "Reptiles" } };
        public ObservableCollection<animalTypes2> Source2
        {
            get { return _source2; }
        }
        private bool _isSource2;
        public bool IsSource2
        {
            get { return _isSource2; }
            set
            {
                if (value != _isSource2)
                {
                    _isSource2 = value;
                    OnPropertyChanged("IsSource2");
                }
            }
        }
       
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;          
        }
        private void btn1_click(object sender, RoutedEventArgs e)
        {
            IsSource2 = false;
        }
        private void btn_click2(object sender, RoutedEventArgs e)
        {
            IsSource2 = true;
        }
    }
