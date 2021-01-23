            foreach (var group in WebLinksList.GroupBy(wl => wl.Level))
            {
                ToolStripMenuItem tm = new ToolStripMenuItem();
                tm.Text = group.Key;
                tm.DropDownItemClicked += Tm_DropDownItemClicked;
                tm.DropDownItems.AddRange(group.Select(w => new ToolStripMenuItem(w.Name)).ToArray<ToolStripItem>());
                contextMenuStripMain.Items.Add(tm);
            }
