    Timer t1 = new Timer();
    int ticks = 0;
    private void button1_Click(object sender, EventArgs e)
    {
      button1.Enabled = false;
      t1.Interval = Convert.ToInt32(numericUpDown1.Value);
      ticks = 0;
      t1.Start();
      t1.Tick += Timer_Tick;
    }
    private void Timer_Tick(object sender, EventArgs e)
    {
      if (ticks <  Convert.ToInt32(numericUpDown2.Value))
      {
        ticks++;
        //Get x/y coordinates of mouse
        int X = Cursor.Position.X;
        int Y = Cursor.Position.Y;
        //Click mouse at x/y coordinates
        mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
      }
      else
      {
        t1.Stop(); //You could Call Stop from every where e.g. from another Button
        button1.Enabled = true;
      }
    }
