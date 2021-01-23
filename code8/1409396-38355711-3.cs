    protected void LocationView_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName == "UnSelect")
        {
            ListView1.SelectedIndex = -1;
            ListView1.DataBind();
        }
    }
