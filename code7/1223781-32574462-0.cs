    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.listView1.Items.Cast<ListViewItem>()
            .ToList().ForEach(item =>
            {
                item.BackColor = SystemColors.Window;
            });
        this.listView1.SelectedItems.Cast<ListViewItem>()
            .ToList().ForEach(item =>
            {
                item.BackColor = SystemColors.Highlight;
            });
    }
