    public Form1()
        {
            InitializeComponent();
            Rectangle rcScreen = Screen.PrimaryScreen.WorkingArea;
            this.Location = new System.Drawing.Point((rcScreen.Left + rcScreen.Right) / 2 - (this.Width / 2), 0);
        }
