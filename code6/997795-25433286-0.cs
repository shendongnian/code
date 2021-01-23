    public class DialogForm : Form
    {
        private struct WindowPos
        {
            public int hwnd;
            public int hwndInsertAfter;
            public int x;
            public int y;
            public int cx;
            public int cy;
            public uint flags;
        }
        public DialogForm()
        {
        }
        protected override void WndProc(ref Message m)
        {
            const int WM_WINDOWPOSCHANGING = 0x0046;
            if (m.Msg == WM_WINDOWPOSCHANGING)
            {
                WindowPos mwp = (WindowPos)Marshal.PtrToStructure(m.LParam, typeof(WindowPos));
                if (mwp.hwnd == Handle.ToInt32())
                {
                    const int SWP_NOMOVE = 0x0002;
                    const int SWP_NOSIZE = 0x0001;
                    int x = mwp.x;
                    int y = mwp.y;
                    if (x < Owner.Left || y < Owner.Top || x + mwp.cx > Owner.Right || y + mwp.cy > Owner.Bottom)
                    {
                        m.Result = IntPtr.Zero;
                        mwp.flags |= SWP_NOMOVE | SWP_NOSIZE;
                        Marshal.StructureToPtr(mwp, m.LParam, true);
                    }
                }
            }
            base.WndProc(ref m);
        }
    }
