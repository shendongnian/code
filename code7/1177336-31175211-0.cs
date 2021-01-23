    lstMain.Items
        .Cast<ListItem>()
        .ToList()
        .ForEach( item =>
            {
                if(item.Selected)
                {
                    lstFAvourite.Items.Add(item);
                    lstMain.Items.Remove(item);
                }
            }
        );
    lstFAvourite.ClearSelection();
