    private Point PointToWindow(Point screenPoint)
    {
        return new Point(screenPoint.X - Location.X, screenPoint.Y - Location.Y);
    }
    protected override void WndProc(ref Message m)
    {
        if (m.Msg == WM_NCMOUSEMOVE)
        {
            // Get in client coordinates.
            var clientPoint = this.PointToWindow(new Point(msg.LParam.ToInt32()));
            var evt = new MouseEventArgs(MouseButtons.None, 0, clientPoint.X, clientPoint.Y, 0);
            base.OnMouseMove(evt);
                
            // The line below is what would normally be done when this message is received:
            // OnNcMouseMove(evt);
        }
        base.WndProc(ref m);
    }
  
