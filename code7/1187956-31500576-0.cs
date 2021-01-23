    public void PopDDL()
    {
        FORM1.SelectCommand = "SELECT CompanyName FROM Company ORDER BY CASE WHEN CompanyName='Select' THEN 0 ELSE 1 END;"
        ddlSource.DataSourceID = "FORM1";
        ddlSource.DataTextField = "CompanyName";
        ddlSource.DataValueField = "CompanyName";
        ddlSource.DataBind();
        foreach (ListItem itm in ddlSource.Items) {
            if (itm.Value == "Select") {
                itm.Attributes.Add("disabled", "disabled");
            }
        }
    }
    
    protected void Page_Load(object sender, System.EventArgs e)
    {
        PopDDL();
    }
