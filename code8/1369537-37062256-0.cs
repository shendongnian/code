    float angle = 0;
    float rotSpeed = 1;
    Point origin = new Point(222, 222);  // your origin
    int distance = 100;                  // your distance
    private void timer1_Tick(object sender, EventArgs e)
    {
        angle += rotSpeed;
        int x = (int)(origin.X + distance * Math.Sin(angle *Math.PI / 180f));
        int y = (int)(origin.Y + distance * Math.Cos(angle *Math.PI / 180f));
        yourControl.Location = new Point(x, y);
    }
