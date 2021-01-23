    public partial class MainWindow : Window
    {
        public int[] Rows{ get; set; }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            this.Rows= new int[] { 1, 2, 1, 3 };
        }
    }
