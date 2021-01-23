    protected void loginfo_click(Object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        Response.Write("<script>");
        Response.Write("window.open('loginfo.aspx?id=" + btn.CommandArgument + "','_blank')");
        Response.Write("</script>");
    }
