    private void configure()
    {
        pictureBox1.Paint += new PaintEventHandler(pictureBox1_OnPaint);
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        pictureBox1.Invalidate();
    }
    private void pictureBox1_OnPaint(object sender, PaintEventArgs e)
    {
        foreach (Line line in lines)//array "lines" contains just 16 objects
        {
            //calculating new coordinates ...
            e.Graphics.DrawLine(new Pen(Brushes.Black, 5f), line.P1, line.P2);
            e.Graphics.FillEllipse(Brushes.Red, line.P1.X - 2.5f, line.P1.Y - 2.5f, 5, 5);
            e.Graphics.FillEllipse(Brushes.Red, line.P2.X - 2.5f, line.P2.Y - 2.5f, 5, 5);
            e.Graphics.DrawEllipse(new Pen(Brushes.Red, 5f), line.P1.X, line.P1.Y, 1, 1);
            e.Graphics.DrawEllipse(new Pen(Brushes.Red, 5f), line.P2.X, line.P2.Y, 1, 1);
        }
    }
