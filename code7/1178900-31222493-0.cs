    private ObservableCollection<string> _names = new ObservableCollection<string>()
        {
            "Isabel", "Michal"
        };
        public ObservableCollection<string> Names
        {
            get { return _names; }
            set { _names = value; }
        }
        private ICollectionView View;
        public MainWindow()
        {
            InitializeComponent();
            ListBox.ItemsSource = Names;
            View = CollectionViewSource.GetDefaultView(Names);
        }
        private void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            View.Filter = x => x.ToString().ToLower().Contains(((TextBox)sender).Text.ToLower());
        }
