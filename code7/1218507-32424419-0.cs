    private void ListViewSample_Load(object sender, EventArgs e)
    {
        //Set width
        var otherItemWisth= this.listView1.Columns.Cast<ColumnHeader>()
            .Where(x => x.Index < this.listView1.Columns.Count - 1)
            .Sum(x => x.Width);
        this.listView1.Columns[this.listView1.Columns.Count - 1].Width = this.listView1.Width - otherItemWisth;
    }
    private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
    {
        //Draw headers
        var renderer = new VisualStyleRenderer(VisualStyleElement.Header.Item.Normal);
        renderer.DrawBackground(e.Graphics, new Rectangle(e.Bounds.X+1, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
        renderer.DrawText(e.Graphics, e.Bounds, e.Header.Text, false, 
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine);
    }
    private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
    {
        //Default draw for items
        e.DrawDefault = true;
    }
    private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
    {
        //Default draw for sub items
        e.DrawDefault = true;
    }
