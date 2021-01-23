    public partial class Form1 : Form
    {
    	private string[] linkstoextract;
    	private int numberoflinks;
    	private int currentLinkNumber = 0;
    	private string mainlink;
    	private WebClient client;
    	private WebBrowser webBrowser1;
    
    	public Form1()
    	{
    		InitializeComponent();
    
    		webBrowser1 = new WebBrowser();
    		webBrowser1.DocumentCompleted += webBrowser1_DocumentCompleted;
    
    		label1.Text = "Number of links: ";
    
    		mainlink = "http://www.test.com/index";
    		numberoflinks = 211;
    		
    		ProcessNextLink();
    	}
    	
    	private void ProcessNextLink()
    	{
    		if (currentLinkNumber < numberoflinks)
    		{
    			currentLinkNumber++;
    			webBrowser1.Navigate(mainlink + currentLinkNumber.ToString() + ".html");
    		}	
    	}
    	
    	void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    	{
    		ProcessImagesFromDocument();
    		ProcessNextLink();
    	}
    
    	private void ProcessImagesFromDocument()
    	{
    		IHTMLDocument2 doc = (IHTMLDocument2)webBrowser1.Document.DomDocument;
    		IHTMLControlRange imgRange = (IHTMLControlRange)((HTMLBody)doc.body).createControlRange();
    
    		foreach (IHTMLImgElement img in doc.images)
    		{
    			imgRange.add((IHTMLControlElement)img);
    			imgRange.execCommand("Copy", false, null);
    
    			using (Bitmap bmp = (Bitmap)Clipboard.GetDataObject().GetData(DataFormats.Bitmap))
    			{
    				bmp.Save(@"C:\" + img.nameProp);
    			}
    		}
    
    	}
    
    }
