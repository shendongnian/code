    MenuItem mi = sender as MenuItem;
    if (mi != null)
    {
        ContextMenu cm = mi.CommandParameter as ContextMenu;
        if (cm != null)
        {
            TextBlock t = cm.PlacementTarget as TextBlock;
            if (t != null)
            {
                // print t.Name or whatever...
            }
        }
    }
