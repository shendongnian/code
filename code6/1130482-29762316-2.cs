    protected override void WndProc(ref Message m)
    {
        if (m.Msg == WM_NCMOUSEMOVE)
        {
            // Get in client coordinates.
            var clientPoint = this.PointToClient(new Point(msg.LParam.ToInt32()));
            var evt = new MouseEventArgs(MouseButtons.None, 0, clientPoint.X, clientPoint.Y, 0);
            base.OnMouseMove(evt);
        }
        base.WndProc(ref m);
    }
  
