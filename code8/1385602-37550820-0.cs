    private string url = "";
	public Form1()
	{
		InitializeComponent();
		WebBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowser1_DocumentCompleted);
		WebBrowser1.NewWindow += new System.ComponentModel.CancelEventHandler(webBrowser1_NewWindow);
	}
	void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
	{
		HtmlElementCollection links = WebBrowser1.Document.Links;
		foreach (HtmlElement var in links)
		{
			var.AttachEventHandler("onclick", LinkClicked);
		}
	}
	private void LinkClicked(object sender, EventArgs e)
	{
		HtmlElement link = WebBrowser1.Document.ActiveElement;
		url = link.GetAttribute("href");
	}
	void webBrowser1_NewWindow(object sender, System.ComponentModel.CancelEventArgs e)
	{
		WebBrowser webBrowser = (WebBrowser)sender;
		HtmlElement link = webBrowser.Document.ActiveElement;
		Uri urlNavigated = new Uri(link.GetAttribute("href"));
		WebBrowser1.Navigate(url);
		e.Cancel = true;
	}
