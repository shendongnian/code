    protected void ddlNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlText.Enabled = ddlNumber.SelectedValue == "";
        ddlNumber.Enabled = ddlText.SelectedValue == "";
    }
 
