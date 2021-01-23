     protected void AutoGenerateTable_EditCommand(object source, DataGridCommandEventArgs e)
    {
      AutoGenerateTable.EditItemIndex = e.Item.ItemIndex;
      DropDownList FlagFropDown= e.Item.FindControl("FlagFropDown") as DropDownList
      Literal  FlagText= e.Item.FindControl("FlagText") as Literal 
     if(FlagFropDown!=null)
      {  
       string value=FlagText.Text.Trim();
       if(FlagFropDown!=null)
       {
           //now you have got the object of dropdown
           //If you want to do any opertaion on dropdown can write code for it.
            FlagFropDown.Items.FindByText(value).Selected = true;
        }
      }
    }
