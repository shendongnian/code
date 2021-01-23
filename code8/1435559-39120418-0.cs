    System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
    public void LeftMouseClick(int xpos, int ypos)
    {
            SetCursorPos(xpos, ypos);
            mouse_event(MOUSEEVENTF_LEFTDOWN, xpos, ypos, 0,0);
            mouse_event(MOUSEEVENTF_LEFTUP, xpos, ypos, 0, 0);
            mouse_event(MOUSEEVENTF_MOVE, xpos+5, ypos+5, 0, 0);
            timer.Interval = 1000; // here time in milliseconds
            timer.Tick += timer_Tick;
            timer.Start();
            
     }
     void timer_Tick(object sender, System.EventArgs e)
     {
            SetCursorPos(1500, 28);
            timer.Stop();
     }
