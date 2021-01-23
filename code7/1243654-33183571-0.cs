    public Form1()
    {
    	InitializeComponent();
    	buttonSearch.Click += buttonSearch_Click;
    }
    
    private void buttonSearch_Click(object sender, EventArgs e)
    {
    	webBrowser1.DocumentCompleted += WebBrowser1_DocumentCompleted;
    	string url = "http://www.mediabanken.se/Site/Start.aspx";
    	webBrowser1.Navigate(url);
    }
    
    private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
    	// Check the search results are shown 
    	string className = "ProductImageControl_Image";
    	// Get all "img" elements
    	HtmlElementCollection images = webBrowser1.Document.GetElementsByTagName("img");
    	// Select the image with "ProductImageControl_Image" class
    	HtmlElement image = images.Cast<HtmlElement>().FirstOrDefault(i => i.GetAttribute("className") == className);
    	if (image != null)  // result image has been shown
    	{
    		// Click the image
    		image.InvokeMember("click");
    		// Unregister handler
    		this.webBrowser1.DocumentCompleted -= WebBrowser1_DocumentCompleted;
    	}
    	else
    	{
    		// Get all input elements
    		HtmlElementCollection inputs = webBrowser1.Document.GetElementsByTagName("input");
    		// Select "txtSearch" input
    		HtmlElement input = inputs["txtSearch"];
    		if (input != null)
    		{
    			string value = input.GetAttribute("VALUE");
    			if (!string.IsNullOrEmpty(value))
    			{
    				// Already searched but no results
    			}
    			else
    			{
    				// Input search text
    				string searchText = textBoxSearch.Text;
    				input.SetAttribute("VALUE", searchText);
    				SendKeys.Send("{ENTER}");
    			}
    		}
    	}
    }
