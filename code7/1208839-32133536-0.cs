    Point? start = null;
    public void panel1_MouseDown(object sender, MouseEventArgs e)
    {
        start = new Point(e.X, e.Y);
    }
    public void panel1_MouseUp(object sender, MouseEventArgs e)
    {
        start = null;
    }
    public void panel1_MouseMove(object sender, MouseEventArgs e)
    {
        if(start.HasValue)
          if(MousePosition.X > start.Value.X)
            Console.WriteLine("you have moved right");
    }
