    using System;
    using System.Windows.Forms;
    using System.Drawing;
    
    class SelectablePictureBox : PictureBox {
        public SelectablePictureBox() {
            this.SetStyle(ControlStyles.Selectable, true);
            this.TabStop = true;
        }
        protected override void OnMouseDown(MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) this.Focus();
            base.OnMouseDown(e);
        }
        protected override void OnEnter(EventArgs e) {
            this.Invalidate();
            base.OnEnter(e);
        }
        protected override void OnLeave(EventArgs e) {
            this.Invalidate();
            base.OnLeave(e);
        }
        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            if (this.Focused) {
                var rc = this.DisplayRectangle;
                rc.Inflate(new Size(-2, -2));
                ControlPaint.DrawFocusRectangle(e.Graphics, rc);
            }
        }
    }
