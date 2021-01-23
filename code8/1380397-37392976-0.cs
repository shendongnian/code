    protected void UpdateButton(object sender, EventArgs e) 
    {
        var masterPage = this.Page.Master;
        var updatePanel = masterPage.FindControl("Panel2");
    
        var div = (HtmlGenericControl)updatePanel.FindControl("updateThis");
        div.Style.Add("color", "#ff0000");  
    }
