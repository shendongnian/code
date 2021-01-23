    public partial class Form1 : Form
    {
        private void Form1_Load(object sender, EventArgs e)
        {
            this.webBrowser1.Navigate(@"d:\test.html");
            this.webBrowser1.DocumentCompleted += webBrowser1_DocumentCompleted;
        }
        
        bool completed = false;
        void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url == webBrowser1.Document.Url)
            {
                completed = true;
            }
        }
        private void clickToolStripButton_Click(object sender, EventArgs e)
        {
            if(completed)
            {
                var frame = webBrowser1.Document.Window.Frames["iframeid"];
                var button = frame.Document.GetElementById("buttonid");
                button.InvokeMember("click");
            }
        }
    }
