    int sortIndex = 0;
    private void listView1_DrawColumnHeader(object sender,
       DrawListViewColumnHeaderEventArgs e)
    {
        var state = e.State == ListViewItemStates.Selected ?
            VisualStyleElement.Header.Item.Hot : VisualStyleElement.Header.Item.Normal;
        var sortOrder = listView1.Sorting == SortOrder.Ascending ?
            VisualStyleElement.Header.SortArrow.SortedUp :
            VisualStyleElement.Header.SortArrow.SortedDown;
        var itemRenderer = new VisualStyleRenderer(state);
        var sortRenderer = new VisualStyleRenderer(sortOrder);
        var r = e.Bounds; 
        r.X += 1;
        itemRenderer.DrawBackground(e.Graphics, r);
        r.Inflate(-2, 0);
        var flags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter |
            TextFormatFlags.SingleLine;
        itemRenderer.DrawText(e.Graphics, r, e.Header.Text, false, flags);
        var d = SystemInformation.VerticalScrollBarWidth;
        if (e.ColumnIndex == sortIndex) //Sorted Column
            sortRenderer.DrawBackground(e.Graphics, 
                new Rectangle(r.Right - d, r.Top, d, r.Height));
    }
    private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
    {
        e.DrawDefault = true;  /*Use default rendering*/
    }
    private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
    {
        e.DrawDefault = true;  /*Use default rendering*/
    }
