    Private Point start;
    
    public void panel1_MouseDown(object sender, MouseEventArgs e)
    {
        this.start = new Point(e.X, e.Y);
    }
    public void panel1_MouseMove(object sender, MouseEventArgs e)
    {
            if(MousePosition.X > this.start.X)
            {
                Console.WriteLine("you have moved right");
            }
    }
