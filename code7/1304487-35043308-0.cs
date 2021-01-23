    const int WM_NCHITTEST = 0x84, HTTRANSPARENT = (-1);
    class HitTestTransparentPictureBox : PictureBox {
        protected override void WndProc(ref Message m) {
            if(m.Msg == WM_NCHITTEST) {
                m.Result = new IntPtr(HTTRANSPARENT);
                return;
            }
            base.WndProc(ref m);
        }
    }
    class HitTestTransparentLabel : Label {
        protected override void WndProc(ref Message m) {
            if(m.Msg == WM_NCHITTEST) {
                m.Result = new IntPtr(HTTRANSPARENT);
                return;
            }
            base.WndProc(ref m);
        }
    }
