    protected void Page_PreRender(object sender, EventArgs e)
    {
          Label lblCreateDate = ((Label)gvMainView.FooterRow.FindControl("lblCreateDate")).Text;
        lblCreateDate.Text = AutoDate;
        Label lblWebsite = ((Label)gvMainView.FooterRow.FindControl("lblWebsite")).Text;
        lblWebsite.Text = Website;
    }
