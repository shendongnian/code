      protected void AutoGenerateTable_EditCommand(object source, DataGridCommandEventArgs e)
            {
                // / Set the EditItemIndex property to the index of the item clicked 
                // in the DataGrid control to enable editing for that item. Be sure
                // to rebind the DateGrid to the data source to refresh the control.
                AutoGenerateTable.EditItemIndex = e.Item.ItemIndex;
                BindGrid();
            }
    
  
        protected void AutoGenerateTable_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            Literal FlagText = null;
            if (e.Item.ItemType == ListItemType.Item)
            {
                FlagText = e.Item.FindControl("FlagText") as Literal;
            }
            if (e.Item.ItemType == ListItemType.EditItem)
            {
                DropDownList FlagFropDown = e.Item.FindControl("FlagFropDown") as DropDownList;
                if (FlagText != null)
                {
                    string value = FlagText.Text.Trim();
                    if (FlagFropDown != null)
                    {
                        //now you have got the object of dropdown
                        //If you want to do any opertaion on dropdown can write code for it.
                        FlagFropDown.Items.FindByText(value).Selected = true;
                    }
                }
            }
        } 
