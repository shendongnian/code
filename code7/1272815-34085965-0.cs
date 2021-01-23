    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    class ListViewEx : ListView {
        public event KeyEventHandler LabelKeyDown = delegate { };
        public event KeyEventHandler LabelKeyUp = delegate { };
        public event KeyPressEventHandler LabelKeyPress = delegate { };
        private LabelTextBox Label;
    
        public ListViewEx() {
            Label = new LabelTextBox(this);
        }
        protected void OnLabelKeyDown(KeyEventArgs e) { LabelKeyDown(this, e); }
        protected void OnLabelKeyUp(KeyEventArgs e) { LabelKeyUp(this, e); }
        protected void OnLabelKeyPress(KeyPressEventArgs e) { LabelKeyPress(this, e); }
    
        protected override void OnBeforeLabelEdit(LabelEditEventArgs e) {
            const int LVM_GETEDITCONTROL = 0x1000 + 24;
            var hdl = SendMessage(this.Handle, LVM_GETEDITCONTROL, IntPtr.Zero, IntPtr.Zero);
            Label.AssignHandle(hdl);
            base.OnBeforeLabelEdit(e);
        }
        protected override void OnAfterLabelEdit(LabelEditEventArgs e) {
            Label.ReleaseHandle();
            base.OnAfterLabelEdit(e);
        }
    
        private class LabelTextBox : NativeWindow {
            private ListViewEx Parent;
            public LabelTextBox(ListViewEx parent) { this.Parent = parent; }
    
            protected override void WndProc(ref Message m) {
                switch (m.Msg) {
                    case 0x100:
                        var args = new KeyEventArgs((Keys)m.WParam.ToInt32());
                        Parent.OnLabelKeyDown(args);
                        if (args.Handled) return;
                        break;
                    case 0x101:
                        var args2 = new KeyEventArgs((Keys)m.WParam.ToInt32());
                        Parent.OnLabelKeyUp(args2);
                        break;
                    case 0x102:
                        var args3 = new KeyPressEventArgs((char)m.WParam.ToInt32());
                        Parent.OnLabelKeyPress(args3);
                        if (args3.Handled) return;
                        break;
                }
                base.WndProc(ref m);
            }
        }
    
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
    }
