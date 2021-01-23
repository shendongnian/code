    protected override void WndProc(ref Message m) {
            switch (m.Msg) {
                case NativeMethods.WM_REFLECT + NativeMethods.WM_COMMAND:
                    if (NativeMethods.Util.HIWORD(m.WParam) == NativeMethods.BN_CLICKED) {
                        Debug.Assert(!GetStyle(ControlStyles.UserPaint), "Shouldn't get BN_CLICKED when UserPaint");
                        if (!ValidationCancelled) {
                            OnClick(EventArgs.Empty);
                        }                        
                    }
                    break;
                case NativeMethods.WM_ERASEBKGND:
                    DefWndProc(ref m);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
