    if(c is MenuStrip)
    {
        foreach(ToolStripMenuItem tsItem in (MenuStrip)c)
        {
            if (tsItem.Name == item)
            {
                tsItem.PerformClick();
            }
        }
    }
