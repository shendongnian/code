    protected void OnUpdate(object sender, EventArgs e)
    {
        LinkButton LinkButton2 = sender as LinkButton;
        GridViewRow row = LinkButton2.NamingContainer as GridViewRow; //Get the gridview row
        Label lblid = row.FindControl("lblid") as Label;
        string qouteid = lblid.Text;
    }
