    protected void Link_Command(object sender, CommandEventArgs e)
    {
        Session["key"] = Guid.NewGuid().ToString().Replace("-", string.Empty);
        Response.Redirect(e.CommandArgument.ToString());
    }
