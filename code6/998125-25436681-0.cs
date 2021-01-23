    protected void click(object sender, EventArgs e)
    {
        Button btnRemove = (Button) sender;
        RepeaterItem item = (RepeaterItem) btnRemove.NamingContainer;
        // for example:
        Label labelSmallInline = (Label) item.FindControl("labelSmallInline");
    }
