    protected void ListView1_ItemDeleting(object sender, ListViewDeleteEventArgs e)
    {
        List<TableDetails> lstDetails = Session["ListView1Data"] as List<TableDetails>;
        if (lstDetails.Count >= e.ItemIndex + 1)
        {
            var tableDetail = lstDetails[e.ItemIndex];
            DeletedItems(tableDetail);
            lstDetails.Remove(tableDetail);
            ListView1.EditIndex = -1;
            Session["ListView1Data"] = lstDetails;
            BindData();
        }
    }
    private void DeletedItems(TableDetails tableDetail)
    {
        List<TableDetails> lstDelItems = new List<TableDetails>();
        if (Session["DeletedItems"] != null)
        {
            lstDelItems = Session["DeletedItems"] as List<TableDetails>;
        }
        // No need to keep track of New Items(whose ID is 0)
        if (tableDetail.Id > 0)
        {
            lstDelItems.Add(tableDetail);
            Session["DeletedItems"] = lstDelItems;
        }
     }
