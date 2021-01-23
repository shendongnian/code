    private void CreateMenu()
    {
        foreach (var group in WebLinksList.GroupBy(wl => wl.Item1.Group))
	    {
            var groupItem = new ToolStripMenuItem(group.Key);
            contextMenuStripMain.Items.Add(groupItem);
            groupItem.DropDownItems.AddRange(group.Select(w => new ToolStripMenuItem(w.Item1.Name)).ToArray<ToolStripItem>());
        }
        contextMenuStripMain.Items.Add("-");
        contextMenuStripMain.Items.Add("Settings");
        contextMenuStripMain.Items.Add("Exit");
    }
