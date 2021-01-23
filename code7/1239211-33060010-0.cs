    using System;
    using System.Windows.Forms;
    
    class MyPanel : Panel {
        public MyPanel() {
            this.DoubleBuffered = this.ResizeRedraw = true;
        }
        protected override void OnPaint(PaintEventArgs e) {
            e.Graphics.TranslateTransform(this.AutoScrollPosition.X, this.AutoScrollPosition.Y);
            base.OnPaint(e);
        }
    }
