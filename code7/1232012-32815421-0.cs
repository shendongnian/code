    private void SubMenu_Click(object sender, EventArgs e)
    {
        var currentItem = sender as ToolStripMenuItem;
        if (currentItem != null)
        {
            ((ToolStripMenuItem)currentItem.OwnerItem).DropDownItems
                .Cast<ToolStripMenuItem>().ToList()
                .ForEach(item =>
                {
                    item.Checked = false;
                });
            currentItem.Checked = true;
        }
    }
