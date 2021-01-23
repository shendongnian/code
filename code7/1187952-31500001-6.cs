    public void PopDDL()
    {
    	FORM1.SelectCommand = "SELECT CompanyName FROM Company ORDER BY CompanyName;";
    	ddlSource.DataSourceID = "FORM1";
    	ddlSource.DataTextField = "CompanyName";
    	ddlSource.DataValueField = "CompanyName";
    	ddlSource.DataBind();
    	foreach (ListItem itm in ddlSource.Items) {
    		if (itm.Value == *your_condition*) {
    			itm.Attributes.Add("disabled", "disabled");
    		}
    	}
    }
    
    protected void Page_Load(object sender, System.EventArgs e)
    {
    	PopDDL();
    }
