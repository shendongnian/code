    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<DataTableItem> _Items;
        public ObservableCollection<DataTableItem> Items
        {
            get { return _Items; }
            set
            {
                _Items = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Items"));
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Items = new ObservableCollection<DataTableItem>();
            Task.Factory.StartNew(() =>
            {
                Dispatcher.Invoke(() =>
                {
                    for (int i = 0; i < 10; i++)
                        Items.Add(new DataTableItem() { Data = "Data " + i });
                }
            );
            });
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
