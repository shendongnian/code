    public sealed partial class MainPage : Page
    {
        public DataSource Data { get; set; }
        public MainPage()
        {
            InitializeComponent();
            Data = new DataSource();
        }
    }
