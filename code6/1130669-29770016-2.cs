    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    class LicenseBox : RichTextBox {
        public event EventHandler LicenseViewed;
    
        public override string Text {
            get { return base.Text; }
            set { base.Text = value;  textChanged(); }
        }
    
        public new string Rtf {
            get { return base.Rtf; }
            set { base.Rtf = value; textChanged(); }
        }
    
        private bool eventFired;
    
        private void textChanged() {
            this.SelectAll();
            this.SelectionProtected = true;
            this.SelectionStart = this.SelectionLength = 0;
            eventFired = false;
            checkScrollbar();
        }
    
        private void checkScrollbar() {
            if (eventFired || !this.IsHandleCreated) return;
            var pos = new ScrollInfo();
            pos.cbSize = Marshal.SizeOf(pos);
            pos.fMask = 7;
            if (!GetScrollInfo(this.Handle, SB_VERT, ref pos)) return;
            if (pos.nPos >= pos.nMax - pos.nPage) {
                if (LicenseViewed != null) LicenseViewed(this, EventArgs.Empty);
                eventFired = true;
            }
        }
    
        protected override void WndProc(ref Message m) {
            base.WndProc(ref m);
            if (m.Msg == WM_VSCROLL || m.Msg == WM_MOUSEWHEEL) checkScrollbar();
        }
        // Pinvoke
        private const int WM_VSCROLL = 0x115;
        private const int WM_MOUSEWHEEL = 0x20A;
        private const int SB_VERT = 1;
        private struct ScrollInfo {
            public int cbSize, fMask, nMin, nMax, nPage, nPos, nTrackPos;
        }
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool GetScrollInfo(IntPtr hwnd, int bar, ref ScrollInfo pos);
    
    }
