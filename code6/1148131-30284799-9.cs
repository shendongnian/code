    int itemHeight = 0;  // we need this number!
    int itemLeft = 0;    // we need this number, too
    private void listView1_DrawColumnHeader(object sender,
                                            DrawListViewColumnHeaderEventArgs e)
    {
        Rectangle R0 = listView1.GetItemRect(0);
        itemHeight = R0.Height;   // we need this number!
        itemLeft = R0.Left;       // we need this number too
 
        e.DrawBackground();
        e.DrawText();
    }
    private void listView1_DrawSubItem(object sender,
                                       DrawListViewSubItemEventArgs e)
    {
        Rectangle rrr = listView1.GetItemRect(e.ItemIndex);
        Rectangle rect = e.Bounds;
        Rectangle rect0 = new Rectangle(rect.X - itemLeft , itemHeight * e.ItemIndex,
                                        rect.Width, rect.Height);
        Image img = listView1.BackgroundImage;
        e.Graphics.DrawImage(img, rect, rect0, GraphicsUnit.Pixel);
        using (SolidBrush brush = new SolidBrush(e.SubItem.BackColor))
            e.Graphics.FillRectangle(brush, rect);
        e.DrawText();
    }
