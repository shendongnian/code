      protected void AutoGenerateTable_EditCommand(object source, DataGridCommandEventArgs e)
            {
              // / Set the EditItemIndex property to the index of the item clicked 
             // in the DataGrid control to enable editing for that item. Be sure
             // to rebind the DateGrid to the data source to refresh the control.
                AutoGenerateTable.EditItemIndex = e.Item.ItemIndex;
               DropDownList FlagFropDown= e.Item.FindControl("FlagFropDown") as DropDownList
               Response.Write(FlagFropDown.ID);
              Response.End();
            }
 
