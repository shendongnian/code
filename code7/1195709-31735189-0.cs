    private Bitmap Surface;
    private Graphics g;
    
    private void button1_Click(object sender, EventArgs e)
    {
        RedrawSurface();
    }
    
    private void RedrawSurface()
    {
        tabControl2.Visible = true;
    
        Surface = new Bitmap(FileInfoTab.Width, FileInfoTab.Height, PixelFormat.Format24bpprgb);
        g = Graphics.FromImage(Surface);
    
        Pen p = new Pen(Color.Black);
        for (int y = 158; y < 1000; y += 15)
        {
            for (int x = 120; x < 280; x += 15)
            {
                Random rd = new Random();
                int nm = rd.Next(0, 10);
                if (nm % 2 == 0)
                {
                    SolidBrush sb = new SolidBrush(Color.Red);
                    g.DrawRectangle(p, x, y, 10, 10);
                    g.FillRectangle(sb, x, y, 10, 10);
                    //x += 15;
                }
                else
                {
                    SolidBrush sb_1 = new SolidBrush(Color.Blue);
                    g.DrawRectangle(p, x, y, 10, 10);
                    g.FillRectangle(sb_1, x, y, 10, 10);
                }
            }
        }
    
        g.Dispose();
        FileInfoTab.Invalidate();
    }
    
    private void FileInfoTab_Paint(object sender, PaintEventArgs e)
    {
        if (Surface != null)
        {
            e.Graphics.DrawImage(Surface, 0, 0);
        }
    }
