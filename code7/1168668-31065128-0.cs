    public partial class Form1 : Form
    {
        WebBrowser browser;
        SHDocVw.WebBrowser_V1 browserV1AceCounter;
        byte[] bPostData;
        string sHeader;
        string sURL;
        public Form1()
        {
            InitializeComponent();
            browser = new WebBrowser();
            
            browser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(browserLoaded);
            browser.NewWindow += new CancelEventHandler(WebBrowserNewWindow);
        }
        private void WebBrowserNewWindow(Object sender, CancelEventArgs e)
        {
            browserV1AceCounter = (SHDocVw.WebBrowser_V1)browser.ActiveXInstance;
            browserV1AceCounter.NewWindow += Web_V1_NewWindow;
        }
        private void Web_V1_NewWindow(string URL, int Flags, string TargetFrameName, ref object PostData, string Headers, ref bool Processed)
        {
            try
            {
                Processed = true; //Stop event from being processed
                // Copy necessary info to use in main thread
                sURL = URL;
                bPostData = (byte[])PostData;
                sHeader = Headers;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void browserLoaded(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                if (e.Url.ToString().Contains("loginURL.com"))
                {
                    this.browser.Navigate(sURL, null, bPostData, sHeader);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
