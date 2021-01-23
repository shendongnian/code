    public class EmoticonControl : Control
    {
        public EmoticonControl(string unicode, Image image)
        {
            this.unicode = unicode;
            this.image = image;
        }
        // Set hover, request invalidation:
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            hover = true;
            this.Invalidate();
        }
        // Unset hover, request invalidation:
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            hover = false;
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle clipRectangle = e.ClipRectangle;
            graphics.DrawImage(this.image, 0, 0, this.Size.Width, this.Size.Height);
            // Only do this when hovering:
            if (hover)
            {
                Brush brush = new SolidBrush(this.selectedColor);
                graphics.FillRectangle(new SolidBrush(selectionColor), clipRectangle);
                graphics.DrawRectangle(new Pen(selectionBorderColor), clipRectangle.X, clipRectangle.Y, clipRectangle.Width - 1, clipRectangle.Height - 1);
            }
        }
        // Added flag to track hover status:
        private bool hover = false;
        private string unicode;
        private Image image;
        private Color selectedColor = SystemColors.Highlight;
        private Color selectionColor = Color.FromArgb(50, 0, 0, 150);
        private Color selectionBorderColor = SystemColors.Highlight;
    }
