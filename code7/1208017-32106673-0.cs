    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Redirect("~/login.aspx?from=ORIGINGPAGE"); //Set parameter here
        }
    }
