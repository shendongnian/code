    private void HeaderContextMenu_ItemCreated(object sender, RadMenuEventArgs e)
    {
        switch ((e.Item.Text))
        {
            case "Columns":
                e.Item.Visible = false;
                break;
        }
    }
