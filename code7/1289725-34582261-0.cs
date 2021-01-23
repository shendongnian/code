    private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
        double xdiff = e.X - 50;
        double ydiff = e.Y - 50;
        double dist = Math.Sqrt(xdiff * xdiff + ydiff * ydiff);
        if (dist <= 50)
        {
          // do something here
        }
    }
