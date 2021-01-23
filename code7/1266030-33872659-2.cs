    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string iframeString = "<iframe style=\"display:none\" src=\"http://stackoverflow.com\"></iframe>";
                                    
                myCustomDiv.InnerHtml=iframeString;
            }
        }
 
