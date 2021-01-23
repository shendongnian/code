    public void AutoGenerateTable_Edit(Object sender, DataGridCommandEventArgs e)
    {
        // Put the data grid into edit mode
        AutoGenerateTable.EditItemIndex = e.Item.ItemIndex;
        List<string> flag = new List<string>();
            flag.Add("Auto Fulfill");
            flag.Add("Do Not Auto Fulfill");
        AutoGenerateTable.DataSource = populateTable();
        AutoGenerateTable.DataBind();
        Literal text = e.Item.Cells[3].Controls[1] as Literal;
    
        // Get the row again now that we are in edit mode
        DataGridItem editItem = AutoGenerateTable.Items[e.Item.ItemIndex];
        DropDownList FlagFropDown = (DropDownList)editItem.FindControl("FlagFropDown");
        // ...
    }
