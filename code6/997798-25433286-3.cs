    protected override void WndProc(ref Message m)
    {
        const int WM_WINDOWPOSCHANGING = 0x0046;
        if (m.Msg == WM_WINDOWPOSCHANGING)
        {
            WindowPos mwp = (WindowPos)Marshal.PtrToStructure(m.LParam, typeof (WindowPos));
            if (mwp.hwnd == Handle)
            {
                int x = mwp.x;
                int y = mwp.y;
                if (x < Owner.Left || y < Owner.Top || x + mwp.cx > Owner.Right || y + mwp.cy > Owner.Bottom)
                {
                    bool resizing = mwp.cx != Width || mwp.cy != Height;
                    if (resizing)
                    {
                        if (x < Owner.Left)
                            mwp.x = x = Owner.Left;
                        if (y < Owner.Top)
                            mwp.y = y = Owner.Top;
                        if (mwp.cx > Owner.Right - x)
                            mwp.cx = Owner.Right - x;
                        if (mwp.cy > Owner.Bottom - y)
                            mwp.cy = Owner.Bottom - y;
                    }
                    else
                    {
                        if (x < Owner.Left)
                            mwp.x = Owner.Left;
                        else if (x > Owner.Right - mwp.cx)
                            mwp.x = Owner.Right - mwp.cx;
                        if (y < Owner.Top)
                            mwp.y = Owner.Top;
                        else if (y > Owner.Bottom - mwp.cy)
                            mwp.y = Owner.Bottom - mwp.cy;
                    }
                    m.Result = IntPtr.Zero;
                    Marshal.StructureToPtr(mwp, m.LParam, true);
                }
            }
        }
        base.WndProc(ref m);
    }
