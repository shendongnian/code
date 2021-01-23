    foreach(ListItem listItem in lblMultiSelect.Items)
    {
       if (listItem.Selected == True)
       {
          var val = listItem.Value;
          var txt = listItem.Text; 
       }
    }
