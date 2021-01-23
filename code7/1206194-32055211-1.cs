    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private GridLength blueColumnWidth;
        private GridLength redColumnWidth;
        private ToggleWidthCommand toggleWidthCommand;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            this.BlueColumnWidth = new GridLength(5, GridUnitType.Star);
            this.RedColumnWidth = new GridLength(5, GridUnitType.Star);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public GridLength BlueColumnWidth
        {
            get
            {
                return this.blueColumnWidth;
            }
            set
            {
                this.blueColumnWidth = value; OnPropertyChanged();
            }
        }
        public GridLength RedColumnWidth
        {
            get
            {
                return this.redColumnWidth;
            }
            set
            {
                this.redColumnWidth = value; OnPropertyChanged();
            }
        }
        public ToggleWidthCommand ToggleWidthCommand
        {
            get
            {
                if (this.toggleWidthCommand == null)
                {
                    this.toggleWidthCommand = new ToggleWidthCommand(this);
                }
                return this.toggleWidthCommand;
            }
        }
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
