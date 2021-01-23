    class TransparentPictureBox : PictureBox
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            if (Parent != null)
            {
                using (var bmp = new Bitmap(Parent.Width, Parent.Height))
                {
                    Parent.Controls.Cast<Control>()
                          .Where(c => Parent.Controls.GetChildIndex(c) > Parent.Controls.GetChildIndex(this))
                          .Where(c => c.Bounds.IntersectsWith(this.Bounds))
                          .OrderByDescending(c => Parent.Controls.GetChildIndex(c))
                          .ToList()
                          .ForEach(c => c.DrawToBitmap(bmp, c.Bounds));
                    e.Graphics.DrawImage(bmp, -Left, -Top);
                    if (this.Image != null)
                        e.Graphics.DrawImage(this.Image, this.ClientRectangle);
                }
            }
        }
        public override Color BackColor
        {
            get { return Color.Transparent; }
            set { base.BackColor = Color.Transparent; }
        }
    }
