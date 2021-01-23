    private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
    {
        e.DrawBackground();
        e.Graphics.DrawString(e.Item.Text, e.Item.Font, Brushes.Black, 
             new Rectangle(e.Bounds.Left-2, e.Bounds.Top, e.Bounds.Width, e.Bounds.Height));
    }
    private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
    {
        e.DrawDefault = true;
    }
    private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
    {
        if(e.ColumnIndex>0)
            e.DrawDefault = true;
    }
