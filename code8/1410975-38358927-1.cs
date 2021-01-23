    protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
    {
       if (e.CommandName == RadGrid.EditCommandName)
       {
           // For Normal mode
           GridDataItem item = e.Item as GridDataItem;
           item["column3"].text = comboBox.SelectedText; // can't remember the exact syntax on this
       }
    }
