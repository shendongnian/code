    public class TextBoxEx : TextBox {
        public event EventHandler SelectionChanged;
    
        protected override void WndProc(ref Message m) {
            base.WndProc(ref m);
    
            if (m.Msg == WM_NOTIFY && m.lParam == EN_SELCHANGE) {
                OnSelectionChanged(EventArgs.Empty);
            }
        }
    
        // ...
    }
