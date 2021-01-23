    protected override void WndProc(ref Message m) {
        if (m.Msg == 0xA0) {  // WM_NCMOUSEMOVE.
            var pos = this.PointToClient(new Point(m.LParam.ToInt32()));
            var evt = new MouseEventArgs(Control.MouseButtons, 0, pos.X, pos.Y, 0);
            OnMouseMove(evt);
        }
        base.WndProc(ref m);
    }
