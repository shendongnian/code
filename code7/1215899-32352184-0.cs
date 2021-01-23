    protected void Page_Load(object sender, EventArgs e)
    {
        regiterAdsScript();  
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //functionality to be implemented
    }
    public void regiterAdsScript()
    {
        string adsLink = ads_link(loc);
        // Define the name and type of the client script on the page.
        String csName = "ButtonClickScript";
        Type csType = this.GetType();
        // Get a ClientScriptManager reference from the Page class.
        ClientScriptManager cs = Page.ClientScript;
        // Check to see if the client script is already registered.
        if (!cs.IsClientScriptBlockRegistered(csType, csName))
        {
            StringBuilder csText = new StringBuilder();
            csText.Append("<script type=\"text/javascript\"> \n");
            csText.Append("function DoClick() { alert('MK'); }  \n");
            csText.Append("</script>");
            cs.RegisterClientScriptBlock(csType, csName, csText.ToString());
            Button1.Attributes.Add("onClick", "javascript:DoClick();");
        }
    }
