    public class MonthPicker : DateTimePicker
    {
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NOFITY)
            {
                var nmhdr = (NMHDR)Marshal.PtrToStructure(m.LParam, typeof(NMHDR));
                switch (nmhdr.code)
                {
                    case -950:
                    {
                        var cal = SendMessage(Handle, DTM_GETMONTHCAL, IntPtr.Zero, IntPtr.Zero);
                        SendMessage(cal, MCM_SETCURRENTVIEW, IntPtr.Zero, (IntPtr)1);
                        break;
                    }
                    case MCN_VIEWCHANGE:
                    {
                        var nmviewchange = (NMVIEWCHANGE)Marshal.PtrToStructure(m.LParam, typeof(NMVIEWCHANGE));
                        if (nmviewchange.dwOldView == 1 && nmviewchange.dwNewView == 0)
                        {
                            SendMessage(Handle, DTM_CLOSEMONTHCAL, IntPtr.Zero, IntPtr.Zero);
                        }
                        break;
                    }
                }
            }
            base.WndProc(ref m);
        }
        private const int WM_NOFITY = 0x004e;
        private const int DTM_CLOSEMONTHCAL = 0x1000 + 13;
        private const int DTM_GETMONTHCAL = 0x1000 + 8;
        private const int MCM_SETCURRENTVIEW = 0x1000 + 32;
        private const int MCN_VIEWCHANGE = -750;
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
        [StructLayout(LayoutKind.Sequential)]
        private struct NMHDR
        {
            public IntPtr hwndFrom;
            public IntPtr idFrom;
            public int code;
        }
        [StructLayout(LayoutKind.Sequential)]
        struct NMVIEWCHANGE
        {
            public NMHDR nmhdr;
            public uint dwOldView;
            public uint dwNewView;
        }
    }
