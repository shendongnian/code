    protected override void WndProc(ref Message m)
    {
        if (m.Msg == WM_NCMOUSEMOVE)
        {
            // Get coordinates.
            int x = m.LParam.ToInt32() & 0x0000ffff;
            int y = m.LParam.ToInt32() >> 16;
            var evt = new MouseEventArgs(MouseButtons.None, 0, x, y, 0);
            base.OnMouseMove(evt);
                
            // The line below is what would normally be done when this message is received:
            // OnNcMouseMove(evt);
        }
        base.WndProc(ref m);
    }
  
