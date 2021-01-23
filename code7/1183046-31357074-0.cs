    using System;
    using System.Windows.Forms;
    
    public class LabelEx : Label {
        protected override void WndProc(ref Message m) {
            const int wmNcHitTest = 0x84;
            const int htTransparent = -1;
            if (m.Msg == wmNcHitTest) m.Result = new IntPtr(htTransparent);
            else base.WndProc(ref m);
        }
    }
