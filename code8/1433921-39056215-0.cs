    protected void btnSave_OnClick(object sender, EventArgs e)
    {
        HtmlButton btn = sender as HtmlButton;
        string commandName = btn.Attributes["CommandName"];
        ...
    }
