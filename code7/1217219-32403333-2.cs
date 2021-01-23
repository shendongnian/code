    public class TransparentControl : Control
    {
        private bool showBorder = false;
        private const int WS_EX_TRANSPARENT = 0x20;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | WS_EX_TRANSPARENT;
                return cp;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (showBorder)
            {
                using (var pen = new Pen(this.ForeColor, 5))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, this.ClientRectangle.Width - 1, this.ClientRectangle.Height - 1);
                }
            }
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            showBorder = true;
            this.Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            showBorder = false;
            this.Invalidate();
        }
        protected override void OnClick(EventArgs e)
        {
            MessageBox.Show("Clicked");
        }
    }
