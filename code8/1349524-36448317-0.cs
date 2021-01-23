    private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
    {
        e.DrawDefault = true;
        Size sz = listView1.LargeImageList.ImageSize;
        int w = sz.Width + 4;
        int h = sz.Height + 4;
        int x = (e.Bounds.Width - sz.Width) / 2 + e.Bounds.X - 2;
        int y = e.Bounds.Top ;
        using (Pen pen = new Pen(Color.Red, 2f))
            e.Graphics.DrawRectangle(pen,x,y,w,h);
          
    }
