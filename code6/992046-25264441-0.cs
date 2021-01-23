    private int oldXPosition;
    private int oldYPosition;
    private double oldMapWidth;
    private double oldMapHeight;
    public Form1()
    {
      //stuff, etc
      oldXPosition = pictureBox2.Location.X;
      oldYPosition = pictureBox2.Location.Y;
      oldMapWidth= Width;
      oldMapHeight = Height;
    }
    private void Form1_Resize(object sender, EventArgs e)
    {
      int newXPosition = (int)(oldXPosition * (Width / oldMapWidth));
      int newYPosition = (int)(oldYPosition * (Height / oldMapHeight));
      pictureBox1.Location = new Point(newXPosition, newYPosition);
    }
