    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void RibbonApplicationMenu_DropDownOpened(object sender, EventArgs e)
        {
            // user has opened menu
            Debug.WriteLine("Menu opened.");
            // let's close it from code
            Menu.IsDropDownOpen = false;
        }
    }
