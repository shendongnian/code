    bool mouseIsDown = false;
    Point start;
    public void panel1_MouseDown(object sender, MouseEventArgs e)
    {
        start = new Point(e.X, e.Y);
        mouseIsDown = true;
    }
    public void panel1_MouseUp(object sender, MouseEventArgs e)
    {
        mouseIsDown = false;
    }
    public void panel1_MouseMove(object sender, MouseEventArgs e)
    {
        if(mouseIsDown)
          if(MousePosition.X > start.X)
            Console.WriteLine("you have moved right");
    }
