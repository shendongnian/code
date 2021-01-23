    foreach (ListItem list in lstMain.Items.Reverse())
    {
        if (list.Selected)
        {
            lstFAvourite.ClearSelection();
            lstFAvourite.Items.Add(list);
            lstMain.Items.Remove(list);
        }
    }
