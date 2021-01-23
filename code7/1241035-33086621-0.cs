    using System.Drawing;
    using System.Windows.Forms;
    public class TransparentControl : Control
    {
        public TransparentControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.SupportsTransparentBackColor, true);
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }
    
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.Red, 0, 0, Width, Height);
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x20;
                return cp;
            }
        }
    }
