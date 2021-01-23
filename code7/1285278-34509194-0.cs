    protected void radStoreUsers_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
        try
        {
            LoadGrid(1);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void CheckChanged(Object sender, System.EventArgs e)
    {
        CheckBox box = (CheckBox)sender;
        GridDataItem item = (GridDataItem)box.NamingContainer;
        var rowIndex = item.ItemIndex;
        var idex =  radStoreUsers.MasterTableView.DataKeyValues[rowIndex];
        string datakey = idex["Id"].ToString();
        if (box.Checked)
        {
            PersistRowIndex(datakey);
        }
        else
        {
            RemoveRowIndex(datakey);
        }
    }
    private void PersistRowIndex(string chkId)
    {
        if (!SelectedCustomersIndex.Exists(i => i == chkId))
        {
            SelectedCustomersIndex.Add(chkId);
        }
    }
    private void RemoveRowIndex(string chkId)
    {
        SelectedCustomersIndex.Remove(chkId);
    }
    private List<string> SelectedCustomersIndex
    {
        get
        {
            if (ViewState[SELECTED_CUSTOMERS_INDEX] == null)
            {
                ViewState[SELECTED_CUSTOMERS_INDEX] = new List<string>();
            }
            return (List<string>)ViewState[SELECTED_CUSTOMERS_INDEX];
        }
    }
    protected void radStoreUsers_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridDataItem)
        {
            GridDataItem item = e.Item as GridDataItem;
            CheckBox box = (CheckBox)item.FindControl("chkBox");
            if (item.OwnerTableView.DataMember == "Users")
            {
                if (SelectedCustomersIndex != null)
                {
                    foreach(string id in SelectedCustomersIndex)
                    {
                        if(item.GetDataKeyValue("Id").ToString() == id)
                        {
                            box.Checked = true;
                        }
                    }
                }
            }
        }
    }
