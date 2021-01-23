    protected override void WndProc(ref Message m)
    {
        switch (m.Msg)
        {
            case WM_NCHITTEST:
                base.WndProc(ref m);
                var pos = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                if (pos.X >= this.ClientRectangle.Width - tolerance && pos.Y >= this.ClientRectangle.Height - tolerance)
                    m.Result = new IntPtr(HTBOTTOMRIGHT);
                break;
            default:
                base.WndProc(ref m);
                break;
        }
    }
