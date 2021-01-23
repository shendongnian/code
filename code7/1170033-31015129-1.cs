    public class ListViewWithoutReflectNotify : ListView
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct NMHDR
        {
            public IntPtr hwndFrom;
            public uint idFrom;
            public uint code;
        }
        private const uint NM_CUSTOMDRAW = unchecked((uint) -12);
        public ListViewWithoutReflectNotify()
        {
        }
        protected override void WndProc(ref Message m)
        {
            // WM_REFLECT_NOTIFY
            if (m.Msg == 0x204E)
            {
                m.Result = (IntPtr)0;
                return;
                //the if below never was true on my system so i 'shorted' it
                //delete the 2 lines above if you want to test this yourself
                NMHDR hdr = (NMHDR) m.GetLParam(typeof (NMHDR));
                if (hdr.code == NM_CUSTOMDRAW)
                {
                    Debug.WriteLine("Hit");
                    m.Result = (IntPtr) 0;
                    return;
                }
            }
            base.WndProc(ref m);
        }
    }
