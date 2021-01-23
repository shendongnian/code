    protected void lbnTitle_Click(object sender, EventArgs e)
    {
        LinkButton ClickedLink = (LinkButton) sender;
        Control container = ClickedLink.NamingContainer;
        Panel panel = (Panel) container.FindControl("p" + ClickedLink.ID);
        panel.Visible = true;
    }
