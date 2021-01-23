    public class ListViewToolTipHelper : NativeWindow
    {
        private ListView parentListView;
        private const int WM_NOTIFY = 78;
        private const int TTN_FIRST = -520;
        private const int TTN_NEEDTEXT = (TTN_FIRST - 10);
        public struct NMHDR
        {
            public IntPtr hwndFrom;
            public IntPtr idFrom;
            public Int32 code;
        }
        public bool TooltipEnabled { get; set; }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NOTIFY && !TooltipEnabled)
            {
                var nmHdr = (NMHDR) m.GetLParam(typeof(NMHDR));
                if (nmHdr.code == TTN_NEEDTEXT)
                    return;
            }
            base.WndProc(ref m);
        }
        public ListViewToolTipHelper(ListView listView)
        {
            this.parentListView = listView;
            this.AssignHandle(listView.Handle);
        }
    }
