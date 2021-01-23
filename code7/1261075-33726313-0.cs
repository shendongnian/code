        public MainWindow()
        {
            InitializeComponent();
        }
        public string globalVariable; //this is global variable (easiest one)
        public static string Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            string FolderLocation  = dialog.SelectedPath; //this is c:/folder
            globalVariable=FolderLocation;
        }
        public void MethodX()
        {
         string variableWithValueFromButtonClick=globalVariable;
        //U can use your globalVariable here or wherever u want inside class MainWindow
        }
