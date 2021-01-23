    foreach (ListItem listItem in cblAnimalType.Items)
    {
      if (SelectedCheckBoxes.Contains((int.Parse(listItem.Value))))
       {
         listItem.Selected = true;
       }
    }
