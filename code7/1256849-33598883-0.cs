    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            SomeList = new ObservableCollection<CategoryList>();         
        }
       
        public ObservableCollection<CategoryList> SomeList { get; set; }
    }
