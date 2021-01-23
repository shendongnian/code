        public MainWindow()
        {
            InitializeComponent();
           
            myUserControl1.UpdateText += HandleUpdateText;
        }
        private void HandleUpdateText(String newText)
        {
            myUserControl2.SetText(newText);
        }
