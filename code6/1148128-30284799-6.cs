    int itemHeight = 0;  // we need this number!
    private void listView1_DrawColumnHeader(object sender,
                                            DrawListViewColumnHeaderEventArgs e)
    {
        itemHeight = listView1.GetItemRect(0).Height;  // we need this number!
        e.DrawBackground();
        e.DrawText();
    }
    private void listView1_DrawSubItem(object sender,
                                       DrawListViewSubItemEventArgs e)
    {
        Rectangle rect = e.Bounds;
        Rectangle rect0 = new Rectangle(rect.X, itemHeight * e.ItemIndex,
                                        rect.Width, rect.Height);
        Image img = listView1.BackgroundImage;
        e.Graphics.DrawImage(img, rect, rect0, GraphicsUnit.Pixel);
        using (SolidBrush brush = new SolidBrush(e.SubItem.BackColor))
            e.Graphics.FillRectangle(brush, rect);
        e.DrawText();
    }
