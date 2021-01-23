    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
        {
            // record the current position as the end point if the left button is down
            this.endPoint = e.Location;
            // force a redraw
            this.Invalidate();
        }
    }
