    public class TransparentLabel : Label
    {
        public TransparentLabel()
        {
            this.transparentBackColor = Color.Blue;
            this.opacity = 50;
            this.BackColor = Color.Transparent;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (Parent != null)
            {
                using (var bmp = new Bitmap(Parent.Width, Parent.Height))
                {
                    foreach (Control c in Parent.Controls)
                        if (c.Bounds.IntersectsWith(this.Bounds) & c != this)
                            c.DrawToBitmap(bmp, c.Bounds);
                    e.Graphics.DrawImage(bmp, -Left, -Top);
                    using (var b = new SolidBrush(Color.FromArgb(this.Opacity, this.TransparentBackColor)))
                    {
                        e.Graphics.FillRectangle(b, this.ClientRectangle);
                    }
                    e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                    TextRenderer.DrawText(e.Graphics, this.Text, this.Font, this.ClientRectangle, this.ForeColor, Color.Transparent);
                }
            }
        }
        private int opacity;
        public int Opacity
        {
            get { return opacity; }
            set
            {
                if (value >= 0 && value <= 255)
                    opacity = value;
                this.Invalidate();
            }
        }
        public Color transparentBackColor;
        public Color TransparentBackColor
        {
            get { return transparentBackColor; }
            set
            {
                transparentBackColor = value;
                this.Invalidate();
            }
        }
        [Browsable(false)]
        public override Color BackColor
        {
            get
            {
                return Color.Transparent;
            }
            set
            {
                base.BackColor = Color.Transparent;
            }
        }
    }
