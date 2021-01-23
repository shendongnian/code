    using System;
    using System.Windows.Forms;
    
    class TabControlEx : TabControl {
        private bool recurse;
        protected override void WndProc(ref Message m) {
            const int WM_MOUSEWHEEL = 0x20a;
            if (!recurse && m.Msg == WM_MOUSEWHEEL && this.SelectedTab != null) {
                recurse = true;
                SendMessage(this.SelectedTab.Handle, m.Msg, m.WParam, m.LParam);
                recurse = false;
                m.Result = IntPtr.Zero;
                return;
            }
            base.WndProc(ref m);
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
    }
