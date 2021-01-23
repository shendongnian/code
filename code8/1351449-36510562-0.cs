    private void PerformClickfromString(string s)
    {
        foreach (var c in this.Controls)
        {
            List<ToolStripMenuItem> items = new List<ToolStripMenuItem>();
            if (c is MenuStrip)
            {
                foreach (ToolStripMenuItem tsItem in ((MenuStrip)c).Items)
                {
                    GetAllMenuItems(items, tsItem);
                }
            }
            ToolStripMenuItem found = items.Find(x => x.Name == s);
            if (found != null) found.PerformClick();
        }
    }
    void GetAllMenuItems(List<ToolStripMenuItem> items, ToolStripMenuItem menu)
    {
        items.Add(menu);
        foreach(ToolStripMenuItem m in menu.DropDownItems)
            GetAllMenuItems(items, m);
    }
