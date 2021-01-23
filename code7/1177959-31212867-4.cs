    private void timer1_Tick(object sender, EventArgs e)
    {
        if ( (Control.MouseButtons & MouseButtons.Left) == MouseButtons.None)
        {
            dragFrame.Hide();
            timer1.Stop();
        }
        if (dragFrame.Visible)
        {
            Point pt = this.PointToClient(Cursor.Position);
            dragFrame.Location = new Point(pt.X - mDown.X, 
                                           pt.Y - dragFrame.Height);
            foreach( Control ctl  in dragTargets)
                if (ctl.ClientRectangle.Contains(pt ) )
                {
                    dragFrame.Hide();
                }
        }
    }
