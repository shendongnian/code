    int AnimationCounter = 0;
    Point AnimationCenter = Point.Empty;
    Timer AnimationTimer = new Timer();
    private void pictureBox1 _MouseClick(object sender, MouseEventArgs e)
    {
        AnimationCenter = e.Location;
        AnimationTimer.Interval = 20;
        AnimationTimer.Tick += (ss, ee) =>
            {
                if (AnimationCounter > 10)
                {
                    AnimationCounter = 0;
                    AnimationTimer.Stop();
                    pictureBox1.Invalidate();
                }
                else
                {
                    AnimationCounter += 1;
                    pictureBox1.Invalidate();
                }
            };
        AnimationTimer.Start();
    }
    private void pictureBox1 _Paint(object sender, PaintEventArgs e)
    {
        if (AnimationCounter > 0) 
        {
            int ac = AnimationCounter / 2;
            e.Graphics.DrawEllipse(Pens.Orange, AnimationCenter.X - ac, 
                                                AnimationCenter.Y - ac, ac * 2, ac * 2);
        }
    }
