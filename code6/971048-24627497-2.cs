    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private IShipRepository repository = new CSVShipRepository("d:\\test_data.csv");
        private List<Ship> ships;
        private Ship selectedShip;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        public List<Ship> Ships
        {
            get
            {
                if (ships == null)
                    ships = repository.GetShips();
                return ships;
            }
        }
        public Ship SelectedShip
        {
            get { return selectedShip; }
            set
            {
                if (selectedShip == value) return;
                selectedShip = value;
                NotifyChanged("SelectedShip");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
