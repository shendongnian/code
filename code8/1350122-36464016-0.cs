            public Form1()
        {
            InitializeComponent();
            btnCloseButton.Click += new EventHandler(OnUserControlClick);
            btnOtherRandomButton.Click += new EventHandler(OnUserControlClick);
            btnOtherRandomButton1.Click += new EventHandler(OnUserControlClick);
        }
        private static void OnUserControlClick(object sender, EventArgs e)
        {
            if (sender as UserControl == btnCloseButton)
            {
                this.Close();
            }
        }
