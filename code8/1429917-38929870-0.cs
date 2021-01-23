     public Form1()
        {
            InitializeComponent();
            InitBrowser();          
            this.WindowState = FormWindowState.Maximized;
        }
        public ChromiumWebBrowser browser1;
        public ChromiumWebBrowser browser2;
        public void InitBrowser()
        {
            Cef.Initialize(new CefSettings());
           
            browser1 = new ChromiumWebBrowser("https://www.google.com/");
            this.Controls.Add(browser1);
            browser1.Anchor = AnchorStyles.Top;
            browser1.Location = new Point(-300, 0);
            browser1.Size = new Size(1300, 500);
            browser2 = new ChromiumWebBrowser("https://www.yahoo.com");
            this.Controls.Add(browser2);
            browser2.Anchor = AnchorStyles.Top;
            browser2.Location = new Point(-300, 500);
            browser2.Size = new Size(1300, 200);
            
        }
