    using System;
    using System.Windows.Forms;
    
    class MyPanel : Panel {
        public bool AutoScrollDisabled { get; set; }
    
        protected override void WndProc(ref Message m) {
            const int WM_NCHITTEST = 0x84;
            const int HTCLIENT = 1;
            const int HTHSCROLL = 6;
            const int HTVSCROLL = 7;
    
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST && AutoScrollDisabled) {
                switch (m.Result.ToInt32()) {
                    case HTHSCROLL:
                    case HTVSCROLL: m.Result = new IntPtr(HTCLIENT); break;
                }
            }
        }
    }
