    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Entities = new ObservableCollection<YourEntity>()
            {
                new YourEntity{ Caption = "Name:", Value = "Test Name"},
                new YourEntity{ Caption = "Value1:", Value = "Test Value1"},
                new YourEntity{ Caption = "Value2:", Value = "Test Value2"}
            };
            this.DataContext = this;
        }
        public ICollection<YourEntity> Entities { get; private set; }
    }
