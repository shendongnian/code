    public partial class MainPage : UserControl
    {
        public static MainPage Instance { get; private set; }
        public MainPage()
        {
            InitializeComponent();
            Instance = this;
        }
    }
