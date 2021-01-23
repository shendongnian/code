    public partial class Form1 : Form
    {
        internal List<string> AllHTMLsToPrint = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }
        public void StartPrinting()
        {
            //things added to AllHTMLsToPrint list, please note you may need to add file:/// to the URI list if it is a local file, unless it is compact framework
            // start printing the first item
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.DoWork += bgw_DoWork;
            bgw.RunWorkerAsync();
            /*foreach (string strHTMLToPrint in AllHTMLsToPrint)
            {
                PrintHelpPage(strHTMLToPrint);
            }*/
        }
        void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            PrintHelpPage(AllHTMLsToPrint[0], (BackgroundWorker)sender);
        }
        private void PrintHelpPage(string strHTMLToPrint, BackgroundWorker bgw)
        {
            // Create a WebBrowser instance. 
            WebBrowser webBrowserForPrinting = new WebBrowser();
            // Add an event handler that prints the document after it loads.
            webBrowserForPrinting.DocumentCompleted += (s, ev) => {
                webBrowserForPrinting.Print();
                webBrowserForPrinting.Dispose();
                // you can add progress reporting here
                // remove the first element and see if we have to do it all again
                AllHTMLsToPrint.RemoveAt(0);
                if (AllHTMLsToPrint.Count > 0)
                    PrintHelpPage(AllHTMLsToPrint[0], bgw);
            };
            
            // Set the Url property to load the document.
            webBrowserForPrinting.Url = new Uri(strHTMLToPrint);
        }
    }
