    protected void Page_Load(object sender, EventArgs e)
    {
        if (ddlNumber.SelectedValue == "" && ddlText.SelectedValue == "")
        {
            ddlNumber.Enabled = true;
            ddlText.Enabled = true;
        }
    }
    protected void ddlNumber_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlNumber.SelectedValue != "")
            ddlText.Enabled = false;
        else
            ddlText.Enabled = true;
    }
    protected void ddlText_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlText.SelectedValue != "")
            ddlNumber.Enabled = false;
        else
            ddlNumber.Enabled = true;
    }
