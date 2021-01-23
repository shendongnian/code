    protected void btnSearch_Click(object sender, EventArgs e)
    {
        var searchText = Server.UrlEncode(txtSearchMaster.Text); // URL encode in case of special characters
        Response.Redirect("~/Results.aspx?srch="+searchText);
    }
