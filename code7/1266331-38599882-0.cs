    timer1.Interval=50;
    timer1.Tick+=timer1_Tick;
    timer1.Start();
    
    void timer1_Tick(..)
    {
      pictureBox2.Image = ImageFrame.video;
    }
