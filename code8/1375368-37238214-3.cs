    using System;
    using System.Windows.Forms;
    
    class LinkLabelEx : LinkLabel {
        protected override void OnClick(EventArgs e) {
            var loc = this.PointToClient(Cursor.Position);
            if (this.PointInLink(loc.X, loc.Y) == null) base.OnClick(e);
        }
    }
