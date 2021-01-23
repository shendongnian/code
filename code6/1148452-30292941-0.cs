    ToolStripMenuItem tsmi = new ToolStripMenuItem();
    tsmi.Text = item.Name;
    tsmi.Click += node_Click;
    
    ToolStripItemCollection nodeMenu = nodesToolStripMenuItem.DropDownItems;
    for (int i = 0; i < nodeMenu.Count; i++) {
    	if (item.Category.Equals(nodeMenu[i].Text)) {
    		((ToolStripMenuItem)nodeMenu[i]).DropDownItems.Add(tsmi);
    	} else {
    		ToolStripItem newtsi = nodeMenu.Add(item.Category);
    		((ToolStripMenuItem)newtsi).DropDownItems.Add(tsmi);
    	}
    }
