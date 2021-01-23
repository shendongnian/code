    public class GroupBoxEx : GroupBox
    {
        private Color borderColor = Color.Black;
        [DefaultValue(typeof(Color), "Black")]
        public Color BorderColor
        {
            get
            {
                return borderColor;
            }
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            GroupBoxState state = base.Enabled ? GroupBoxState.Normal : GroupBoxState.Disabled;
            TextFormatFlags flags = TextFormatFlags.PreserveGraphicsTranslateTransform | TextFormatFlags.PreserveGraphicsClipping | TextFormatFlags.TextBoxControl | TextFormatFlags.WordBreak;
            Color textColor = this.ForeColor;
            if (!this.ShowKeyboardCues)
                flags |= TextFormatFlags.HidePrefix;
            if (this.RightToLeft == RightToLeft.Yes)
                flags |= TextFormatFlags.RightToLeft | TextFormatFlags.Right;
            if (!this.Enabled)
                textColor = SystemColors.GrayText;
            DrawUnthemedGroupBoxWithText(e.Graphics, new Rectangle(0, 0, base.Width, base.Height), this.Text, this.Font, textColor, flags, state);
            RaisePaintEvent(this, e);
        }
        private void DrawUnthemedGroupBoxWithText(Graphics g, Rectangle bounds, string groupBoxText, Font font, Color textColor, TextFormatFlags flags, GroupBoxState state)
        {
            Rectangle rectangle = bounds;
            rectangle.Width -= 8;
            Size size = TextRenderer.MeasureText(g, groupBoxText, font, new Size(rectangle.Width, rectangle.Height), flags);
            rectangle.Width = size.Width;
            rectangle.Height = size.Height;
            if ((flags & TextFormatFlags.Right) == TextFormatFlags.Right)
            {
                rectangle.X = (bounds.Right - rectangle.Width) - 8;
            }
            else
            {
                rectangle.X += 8;
            }
            TextRenderer.DrawText(g, groupBoxText, font, rectangle, textColor, flags);
            if (rectangle.Width > 0)
            {
                rectangle.Inflate(2, 0);
            }
            using (var pen = new Pen(this.BorderColor))
            {
                int num = bounds.Top + (font.Height / 2);
                g.DrawLine(pen, bounds.Left, num - 1, bounds.Left, bounds.Height - 2);
                g.DrawLine(pen, bounds.Left, bounds.Height - 2, bounds.Width - 1, bounds.Height - 2);
                g.DrawLine(pen, bounds.Left, num - 1, rectangle.X - 3, num - 1);
                g.DrawLine(pen, (int)((rectangle.X + rectangle.Width) + 2), (int)(num - 1), (int)(bounds.Width - 2), (int)(num - 1));
                g.DrawLine(pen, (int)(bounds.Width - 2), (int)(num - 1), (int)(bounds.Width - 2), (int)(bounds.Height - 2));
            }
        }
    }
