    Point last;  // hold the last mousemove location
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        // store the location in last
        last.X = e.Location.X;
        last.Y = e.Location.Y;
    }
    private void pictureBox1_MouseHover(object sender, EventArgs e)
    {
        // do whatever we want to do with the last location
        Trace.WriteLine(last);
    }
    
