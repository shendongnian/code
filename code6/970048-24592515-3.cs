    using System;
    using System.Drawing;
    using System.Windows.Forms;
    internal class SeeThroughPanel : Panel
    {
        public SeeThroughPanel()
        {
        }
        protected void TickHandler(object sender, EventArgs e)
        {
            this.InvalidateEx();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; //WS_EX_TRANSPARENT
                return cp;
            }
        }
        protected void InvalidateEx()
        {
            if (Parent == null)
            {
                return;
            }
            Rectangle rc = new Rectangle(this.Location, this.Size);
            Parent.Invalidate(rc, true);
        }
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
        }
        private Random r = new Random();
        protected override void OnPaint(PaintEventArgs e)
        {
            
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(128, 0, 0, 0)), this.ClientRectangle);
        }
    }
