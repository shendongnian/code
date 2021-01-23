    private bool IsValidUrl
    {
        set { Session["IsValidUrl"] = true; }
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        IsValidUrl = true;
        Response.Redirect("link2.aspx");
    }
