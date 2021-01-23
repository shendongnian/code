    protected void UpdateInfo(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            GridViewRow row = gv.Rows[e.RowIndex];
            new dalSchool().UpdateLandInfo(row, Session["Uid"].ToString());
            gv.EditIndex = -1;
            BindData();
            MessageController.Show(MessageCode.UpdateSucceeded, MessageType.Confirmation, Page);
        }
        catch (Exception ex)
        {
            MessageController.Show(MessageCode.UpdateFailed, MessageType.Error, Page);
        }
    }
