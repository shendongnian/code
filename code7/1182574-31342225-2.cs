    protected void grdSearchResult_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
            try
            {
                grdSearchResult.DataSource = dtStored;
                grdSearchResult.PageIndex = e.NewPageIndex;
                grdSearchResult.DataBind();
            }
            catch (Exception ex)
            {
                DisplayMessage(GlobalClass.enumMsgType.Error, ex.Message);
            }
    }
