    protected void Page_Load(object sender, EventArgs e)
    {
        lblfield_SelectedIndexChanged(sender, e);
    }
    protected void lblfield_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lblfield.SelectedValue == "OrderDate")
            txtsearch.Visible = false;
        else
            txtsearch.Visible = true;
    }
