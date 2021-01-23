    private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
    {
        e.Graphics.FillRectangle(SystemBrushes.Menu, e.Bounds);
        e.Graphics.DrawRectangle(SystemPens.GradientInactiveCaption, 
            new Rectangle(e.Bounds.X , 0, e.Bounds.Width , e.Bounds.Height) );
        string text = listView1.Columns[e.ColumnIndex].Text;
        TextFormatFlags cFlag = TextFormatFlags.HorizontalCenter 
                              | TextFormatFlags.VerticalCenter;
        TextRenderer.DrawText(e.Graphics, text, listView1.Font, e.Bounds, Color.Black, cFlag);
    }
    private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
    {
        e.DrawDefault = true;
    }
    private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
    {
        e.DrawDefault = true;
    }
