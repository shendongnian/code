     ContextMenuStrip mnu = new ContextMenuStrip();
     ToolStripMenuItem mnuCopy = new ToolStripMenuItem("Copy");
     ToolStripMenuItem mnuCut = new ToolStripMenuItem("Cut");
     mnuCopy.Click += new EventHandler(mnuCopy_Click);
     mnuCut.Click += new EventHandler(mnuCut_Click);
     mnu.MenuItems.AddRange(new MenuItem[] { mnuCopy, mnuCut});
     txt.ContextMenu = mnu;
