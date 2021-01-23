    private void listView3_DrawItem(object sender, DrawListViewItemEventArgs e)
    {
        Rectangle textBounds = e.Bounds; textBounds.Height /= 2;
        e.Graphics.DrawImage(e.Item.Text == "True" ? bmpOn : bmpOff, e.Bounds.Location);
        TextRenderer.DrawText(e.Graphics, e.Item.Tag.ToString(), 
                              Font, textBounds, Color.Black, TFFcenter);
    }
    private void listView3_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
    {
        Rectangle textBounds = e.Bounds; textBounds.Height /= 2;
        e.Graphics.DrawImage(e.SubItem.Text == "True" ? bmpOn : bmpOff, e.Bounds.Location);
        TextRenderer.DrawText(e.Graphics, e.SubItem.Tag.ToString(), 
                              Font, textBounds, Color.Black, TFFcenter);
    }
    private void listView3_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
    {
        e.DrawDefault = true;
    }
