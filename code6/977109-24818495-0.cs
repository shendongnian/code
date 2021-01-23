    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SystemEvents.DisplaySettingsChanged += SystemEvents_DisplaySettingsChanged;
        }
        void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            this.Left = SystemParameters.PrimaryScreenWidth - this.Width;
            this.Top = SystemParameters.PrimaryScreenHeight - this.Height;
        }
    }
