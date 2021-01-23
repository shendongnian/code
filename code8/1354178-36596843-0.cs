    foreach (ListItem item in listbox1.Items)
    {
      if (item.Selected == true)
      {
        listbox2.Items.Add(item);
      }
    }
