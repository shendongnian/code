    protected void SearchBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect(String.Format("~/Results.aspx?search={0}",
            Server.UrlEncode(SearchTB.Text));
    }
