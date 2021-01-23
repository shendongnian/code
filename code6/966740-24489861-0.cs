        DateTime clickTime;
        public void MouseUp(object sender, MouseEventArgs e)
        {
            if (DateTime.Now - clickTime > someDelayTime)
            {
                // Do mouse down 
            }
            else
            {
                // Do mouse click
            }
        }
        public void MouseDown(object sender, MouseEventArgs e)
        {
            clickTime = DateTime.Now;
        }
