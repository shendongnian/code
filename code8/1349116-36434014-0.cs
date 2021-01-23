    protected void chkProductonline_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkProductonline = sender as CheckBox;
        ...
    
        CheckBox chkProduct = chkProductionLine.NamingContainer.FindControl("chkProduct") as CheckBox;
        ...
    }
