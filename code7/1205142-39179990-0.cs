    private void panel1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
        {
            panel1.Refresh();
            using (Graphics g = panel4.CreateGraphics())
            {
                Rectangle rect = GetRectangle(mdown, e.Location);
                g.DrawRectangle(Pens.Red, rect);
            }
        }
    }
    private void panel1_MouseDown(object sender, MouseEventArgs e)
    {
        mdown = e.Location;
    }
