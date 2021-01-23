    private void theOtherPlace_MouseMove(object sender, MouseEventArgs e)
    {
        if (! theOtherPlace.ClientRectangle.Contains(e.Location))
        {
            Point pt = yourUserControl.PointToClient(Control.MousePosition);
            if (yourUserControl.ClientRectangle.Contains(pt))
            {
                yourUserControl_MouseMove(listView1, 
                                new MouseEventArgs(e.Button, e.Clicks, pt.X, pt.Y, e.Delta ) );
            }
        }
    }
