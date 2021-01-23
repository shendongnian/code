    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Tick += timer1_Tick;
            webBrowser1.DocumentCompleted += new 
                WebBrowserDocumentCompletedEventHandler( webBrowser1_DocumentCompleted);
            LoadBrowser();
        }
        void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            webBrowser1.DocumentText = "Cancelled";            
        }
        void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (timer1.Enabled)
            {
                MessageBox.Show("Page Loaded succesfully");
            }
        }
        private void LoadBrowser()
        {
            timer1.Enabled = true;
            webBrowser1.Url = new Uri("http://www.microsoft.com");
        }
        
    }
