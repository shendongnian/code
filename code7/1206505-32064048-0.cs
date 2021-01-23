    private void panel1_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            Pen p = new Pen(Color.Black, 4);
            Graphics g = panel1.CreateGraphics();
            g.DrawRectangle(p, e.X, e.Y, 20, 20);
        }
    }
