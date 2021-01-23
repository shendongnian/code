    cbUpdate.Items.Clear();
    cbUpdate.Items.Add("-Select-");
     
    foreach (string item in thelsit)
    {
      cbUpdate.Items.Add(item.ToString());
    }
    cbUpdate.SelectedIndex = 0;
