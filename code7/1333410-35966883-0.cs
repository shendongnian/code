    public partial class ucMilkshake : UserControl
    {
        private static ucMilkshake _instance;
    
        public int ClickCount { get; private set; }
    
        public static ucMilkshake Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucMilkshake();
                return _instance;
            }
        }
    
        public ucMilkshake()
        {
            InitializeComponent();
        }
    
        public string MS1
        {
            get
            {
                return button11.Text;
            }
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            ClickCount -= 1;
        }
    
        private void button2_Click(object sender, EventArgs e)
        {
            ClickCount = 2;
        }
    }
