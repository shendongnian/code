    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
    
            criteriaBundle = new ObservableCollection<CriteriaItem> {new CriteriaItem("root")};
        }
    
        public ObservableCollection<CriteriaItem> criteriaBundle { get; set; }
    }
