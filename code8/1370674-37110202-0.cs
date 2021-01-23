    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
    	public Form1()
    	{
    	    InitializeComponent();
    	}
    
    	private void Form1_Load(object sender, EventArgs e)
    	{
    	    // When the form loads, open this web page.
    	    webBrowser1.Navigate(" http://localhost/Home.aspx");
    	}
    
    	private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
    	{
    	    // Set text while the page has not yet loaded.
    	    this.Text = "Navigating";
    	}
    
    	private void webBrowser1_DocumentCompleted(object sender,
    	    WebBrowserDocumentCompletedEventArgs e)
    	{
    	    // Better use the e parameter to get the url.
    	    // ... This makes the method more generic and reusable.
    	    this.Text = e.Url.ToString() + " loaded";
    	}
        }
    }
