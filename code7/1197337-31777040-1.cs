    public Form1()
    {
        InitializeComponent();
        webBrowserViewer.DocumentTitleChanged += new EventHandler(webBrowserViewer_DocumentTitleChanged);
    }
    private void webBrowserViewer_DocumentTitleChanged(object sender, EventArgs e)
    {
         label2.Text = webBrowserViewer.DocumentTitle;
    }
