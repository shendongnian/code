    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        ControlPaint.DrawBorder(e.Graphics, this.panel1.ClientRectangle, Color.DarkBlue, ButtonBorderStyle.Solid);
    }
    private void drawboard_MouseMove(object sender, MouseEventArgs e)
    {
        var size = new Size(Math.Max(e.Location.X - panel1.Left, 0), 
            Math.Max(e.Location.Y - panel1.Top, 0));
        if (panel1.Size != size)
        {
            panel1.Size = size;
            panel1.Invalidate();
        }
    }
