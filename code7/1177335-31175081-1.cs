    for (int i = lstMain.Items.Count; i > 0; i--)
    {
        ListItem list = lstMain.Items[i];
        lstFAvourite.ClearSelection();
        lstFAvourite.Items.Add(list);
        lstMain.Items.Remove(list);
    }
