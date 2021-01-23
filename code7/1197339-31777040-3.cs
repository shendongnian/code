    public Form1()
    {
        InitializeComponent();
        webBrowserViewer.DocumentTitleChanged += new EventHandler(webBrowserViewer_DocumentTitleChanged);
    }
    private void webBrowserViewer_DocumentTitleChanged(object sender, EventArgs e)
    {
         label2.Invoke((MethodInvoker)(() => { label2.Text = webBrowser1.DocumentTitle; }));
    }
