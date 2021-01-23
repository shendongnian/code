    protected void pending(object sender, EventArgs e)
    {
        Response.Redirect("OrderHistory.aspx?order=pending", true);
        Session["ReturnURL"] = "OrderHistory.aspx?order=pending";
    }
    protected void confirmed(object sender, EventArgs e)
    {
        Response.Redirect("OrderHistory.aspx?order=confirmed", true);
        Session["ReturnURL"] = "OrderHistory.aspx?order=confirmed";
    }
    protected void rejected(object sender, EventArgs e)
    {
        Response.Redirect("OrderHistory.aspx?order=rejected", true);
        Session["ReturnURL"] = "OrderHistory.aspx?order=rejected";
    }
 
