    protected void MainGridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "select")
        {
            //Binds DetailsView with source data, not loading wrong data from edit mode if user selects previously selected same row again
            DetailsView.DataBind();
            this.mdlPopup.Show();
        }
    }
