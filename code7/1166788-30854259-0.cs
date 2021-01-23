    private List<Ball> balls = new List<Ball>(); // Style Note:  Don't do this, initialize in the constructor.  I know it's legal, but it can cause issues with some code analysis tools.
    private void pbField_Paint(object sender, PaintEventArgs e)
    {
        if (b != null)
        {
            foreach(Ball b in balls)
            {
                b.Paint(e.Graphics);
            }
        }
    }
    private void pbField_MouseClick(object sender, MouseEventArgs e)
    {           
        int width = 10;
        b = new Ball(new Point(e.X - width / 2, e.Y - width / 2), width);
        balls.Add(b);
        Refresh();
    }
