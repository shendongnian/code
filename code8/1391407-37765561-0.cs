    private void EndEditingDetailsView1()
    {
        GridView.DataSourceID = null;
        GridView.EditIndex = -1;
        GridView.DataBind();
        DetailsUpdatePanel.DataBind();
        DetailsUpdatePanel.Update(); 
        GridView.DataSourceID = "SqlDataSource";
        GridView.EditIndex = -1;
        GridView.DataBind();
    }
