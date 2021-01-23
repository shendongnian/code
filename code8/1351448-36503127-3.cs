    if(c is MenuStrip)
    {
        foreach(ToolStripMenuItem tsItem in ((MenuStrip)c).Items)
        {
            if (tsItem.Name == item)
            {
                tsItem.PerformClick();
            }
        }
    }
