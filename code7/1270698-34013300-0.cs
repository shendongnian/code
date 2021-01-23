     protected void LoadOptions3()
      {
         DropDownList3.Items.Clear();
         string selected5;
         selected5 = DropDownList4.SelectedItem.Value;
         //perform db operations
         //loop through values
         DropDownList3.Items.Add(new ListItem(name3, slpCode));
     }
