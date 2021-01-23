            protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x115)
            {
                if (((int)m.WParam & 5) == (5) ||
                    ((int)m.WParam & 4) == (4)
                    )
                {
                    int para = (int)m.WParam;
                    int temp = (para - (para % 2 == 0 ? 4 : 5)) >> 16;
                    // store the current position, if the position doesn't change, no need to handle
                    if (temp == pos)
                        return;
                    else
                        pos = temp;
                }
                if (((int)m.WParam & 8) == 8)
                    return;
                //Debug.WriteLine(m.WParam);
                //if (DisableScroll)
                //    return;
                //    //m.WParam = (IntPtr)8;
                //SCROLLINFO si = new SCROLLINFO();
                //si.cbSize = Marshal.SizeOf(si);
                //si.fMask = (int)(ScrollInfoMask.SIF_POS | ScrollInfoMask.SIF_PAGE | ScrollInfoMask.SIF_RANGE | ScrollInfoMask.SIF_TRACKPOS);
                //GetScrollInfo(this.Handle, 1, ref si);
                ////Debug.WriteLine(string.Format("Max pos:{0}, Min pos: {1}", si.nMin, si.nMax));
                //Debug.WriteLine(string.Format("wParam:{0} hParam:{1}", m.WParam, m.LParam));
                //Debug.WriteLine(string.Format("It page size: {0}, position: {1}, range: {2}, track pos: {3}", si.nPage, si.nPos, si.nPage, si.nTrackPos));
                //if (si.nPage + Math.Max(si.nPos, si.nTrackPos) >= si.nMax)
                //{
                //    return;
                //}
            }
            base.WndProc(ref m);
        }
