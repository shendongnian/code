    protected void ValidateCheckbox()
    {
        bool IsEnabled = false;
    
        foreach (GridDataItem item in RadGrid1.MasterTableView.Items)
        {
            CheckBox CheckBox1 = item["CheckBoxTemplateColumn"].FindControl("CheckBox1") as CheckBox;
            if (CheckBox1.Checked)
            {
                IsEnabled = true;
                break;
            }
        }
    
        GridHeaderItem headerItem = radgridCCBList.MasterTableView.GetItems(GridItemType.Header)[0] as GridHeaderItem;
        if ((headerItem.FindControl("headerChkbox") as CheckBox).Checked)
        {
            IsEnabled = true;
        }
    
        ddlAction.Enabled = IsEnabled;
    }
