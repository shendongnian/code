    private void Form1_MouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
        {
            // setting the point to -1,-1 makes them get drawn off the screen
            startPoint = new Point(-1, -1);
            endPoint = new Point(-1, -1);
            // force an update so that the rectangle disappears
            this.Invalidate();
        }
    }
