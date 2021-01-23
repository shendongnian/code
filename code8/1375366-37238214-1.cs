    using System;
    using System.Windows.Forms;
    
    class LinkLabelEx : LinkLabel {
        bool keyboardUsed = false;
        protected override void OnKeyDown(KeyEventArgs e) {
            keyboardUsed = e.KeyData == Keys.Enter;
            base.OnKeyDown(e);
        }
        protected override void OnClick(EventArgs e) {
            var loc = this.PointToClient(Cursor.Position);
            if (keyboardUsed || this.PointInLink(loc.X, loc.Y) == null) {
                base.OnClick(e);
            }
        }
    }
