    Rectangle currentCrossRect = Rectangle.Empty;
    private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
    {
        Bitmap cross = yourCloseImage;
        int xWidth = cross.Width;
        TabPage tp = tabControl1.TabPages[e.Index];
        e.DrawBackground();
        e.DrawFocusRectangle();
        Size size = tabControl1.ItemSize;
        using (SolidBrush brush = new SolidBrush(e.ForeColor))
            e.Graphics.DrawString(tp.Text, e.Font, brush, e.Bounds.Left + 2 , 5);
        if (tabControl1.SelectedTab == tp)
        {
            currentCrossRect = new Rectangle( 
                               e.Bounds.Left + size.Width - 20, 3, xWidth,xWidth);
            e.Graphics.DrawImage(cross, currentCrossRect.X, currentCrossRect.Y);
        }
    }
    private void tabControl1_MouseClick(object sender, MouseEventArgs e)
    {
        TabPage tp = tabControl1.SelectedTab;
        if (currentCrossRect.Contains(e.Location)) tp.Dispose();
    }
