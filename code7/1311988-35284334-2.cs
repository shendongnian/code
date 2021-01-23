    public class EmoticonControl : Control
    {       
        public EmoticonControl(string unicode, Image image)
        {
            this.unicode = unicode;
            this.image = image;
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            hover = true;
            this.Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            hover = false;
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            DrawImage(e.Graphics);
            DrawSelectionRectangle(e.Graphics);
        }
        private void DrawSelectionRectangle(Graphics graphics)
        {
            if (hover)
            {
                using (var brush = new SolidBrush(selectionColor))
                {
                    graphics.FillRectangle(brush, this.ClientRectangle);
                }
                using (var pen = new Pen(selectionBorderColor))
                {
                    graphics.DrawRectangle(pen,
                        new Rectangle()
                        {
                            Width = (this.Width - 1),
                            Height = (this.Height - 1)
                        });
                }
            }
        }
        private void DrawImage(Graphics graphics)
        {
            if (image != null) graphics.DrawImage(
                this.image, 0, 0, this.Size.Width, this.Size.Height);
        }
        private bool hover = false;
        private Image image;
        private string unicode;
        private Color selectionColor = Color.FromArgb(50, 0, 0, 150);
        private Color selectionBorderColor = SystemColors.Highlight;
    }
