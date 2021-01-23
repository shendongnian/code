    Point mDown = Point.Empty;
    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
        mDown = e.Location;  // note the first corner
    }
    private void Form1_MouseUp(object sender, MouseEventArgs e)
    {
        Invalidate();   // clear the rectangle
    }
    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
        using (Graphics G = this.CreateGraphics() ) // !!! usually wrong !!!
        {
            G.Clear(BackColor); // Invalidate();
            Rectangle rect = rectangle(mDown, e.Location);
            // either
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(32, 255, 0, 0)))
                G.FillRectangle(brush, rect);
            // or
            G.DrawRectangle(Pens.Red, rect);
        }
    }
