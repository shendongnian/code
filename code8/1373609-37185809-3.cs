    private void button1_MouseMove(object sender, MouseEventArgs e)
    {
        Button x = sender as Button;
        Point p = PointToClient(System.Windows.Forms.Control.MousePosition);
        if (p.X > 250|| p.Y >125)
        {
            button1.Size = new Size(250, 125);
            button1.Location = new Point(0, 0);
        }
    }
