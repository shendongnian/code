    if(RoleID == 3)
    {
        btnsave.Enabled = false;
        foreach(GridDataItem item in RadGrid1.MasterTableView.Items)
        {
            HyperLink edit = (HyperLink)item["EditHyperLinkColumn"].Controls[0];
            edit.Enabled = false;
        }
    }
