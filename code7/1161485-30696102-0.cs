    MenuStrip menu = new MenuStrip();
    ToolStripMenuItem test = new ToolStripMenuItem("&test");
    test.DropDownItems.Add("aa", null, aa_click);
    menu.Items.Add(test);
    ToolStripMenuItem test2 = new ToolStripMenuItem("&test2");
    test2.DropDownItems.Add("zz", null, zz_click);
    menu.Items.Add(test2);
    this.Controls.Add(menu);
