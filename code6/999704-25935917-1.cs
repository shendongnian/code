    protected void pnlInputCat_Load(object sender, EventArgs e)
    {
        var theId = Request["__EVENTARGUMENT"];
        if (theId != null && !theId.Equals(string.Empty))
        {
            Session["ItemCode"] = Request["__EVENTARGUMENT"];
            tbxCatalogQty.Focus();		
        }
    }
