    if(c is MenuStrip)
    {
        foreach(object tsObj in (MenuStrip)c)
        {
            ToolStripMenuItem tsItem = (ToolStripMenuItem)tsObj
            if (tsItem.Name == item)
            {
                tsItem.PerformClick();
            }
        }
    }
