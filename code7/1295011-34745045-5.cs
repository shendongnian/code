    public class MyLabel : Label
    {
        private const ContentAlignment anyBottom = ContentAlignment.BottomRight | ContentAlignment.BottomCenter | ContentAlignment.BottomLeft;
        private const ContentAlignment anyMiddle = ContentAlignment.MiddleRight | ContentAlignment.MiddleCenter | ContentAlignment.MiddleLeft;
        private const ContentAlignment anyRight = ContentAlignment.BottomRight | ContentAlignment.MiddleRight | ContentAlignment.TopRight;
        private const ContentAlignment anyCenter = ContentAlignment.BottomCenter | ContentAlignment.MiddleCenter | ContentAlignment.TopCenter;
        protected override void OnPaint(PaintEventArgs e)
        {
            // drawing the label regularly
            if (Enabled)
            {
                base.OnPaint(e);
                return;
            }
            // drawing the background
            Rectangle backRect = new Rectangle(ClientRectangle.X - 1, ClientRectangle.Y - 1, ClientRectangle.Width + 1, ClientRectangle.Height + 1);
            if (BackColor != Color.Transparent)
            {
                using (Brush b = new SolidBrush(BackColor))
                {
                    e.Graphics.FillRectangle(b, backRect);
                }
            }
            // drawing the image
            Image image = Image;
            if (image != null)
            {
                Region oldClip = e.Graphics.Clip;
                Rectangle imageBounds = CalcImageRenderBounds(image, ClientRectangle, RtlTranslateAlignment(ImageAlign));
                e.Graphics.IntersectClip(imageBounds);
                try
                {
                    DrawImage(e.Graphics, image, ClientRectangle, RtlTranslateAlignment(ImageAlign));
                }
                finally
                {
                    e.Graphics.Clip = oldClip;
                }
            }
            // drawing the Text
            Rectangle rect = new Rectangle(ClientRectangle.X + Padding.Left, ClientRectangle.Y + Padding.Top, ClientRectangle.Width - Padding.Horizontal, ClientRectangle.Height - Padding.Vertical);
            TextRenderer.DrawText(e.Graphics, Text, Font, rect, ForeColor, image == null ? BackColor : Color.Transparent, GetFormatFlags());
        }
        private TextFormatFlags GetFormatFlags()
        {
            TextFormatFlags flags = TextFormatFlags.GlyphOverhangPadding | TextFormatFlags.TextBoxControl | TextFormatFlags.WordBreak;
            bool isRtl = RightToLeft == RightToLeft.Yes;
            var contentAlignment = TextAlign;
            if (isRtl)
                contentAlignment = RtlTranslateContent(contentAlignment);
            if ((contentAlignment & anyBottom) != 0)
                flags |= TextFormatFlags.Bottom;
            else if ((contentAlignment & anyMiddle) != 0)
                flags |= TextFormatFlags.VerticalCenter;
            else
                flags |= TextFormatFlags.Top;
            if ((contentAlignment & anyRight) != 0)
                flags |= TextFormatFlags.Right;
            else if ((contentAlignment & anyCenter) != 0)
                flags |= TextFormatFlags.HorizontalCenter;
            else
                flags |= TextFormatFlags.Left;
            if (AutoEllipsis)
                flags |= TextFormatFlags.WordEllipsis | TextFormatFlags.EndEllipsis;
            if (isRtl)
                flags |= TextFormatFlags.RightToLeft;
            if (UseMnemonic)
                flags |= TextFormatFlags.NoPrefix;
            if (!ShowKeyboardCues)
                flags |= TextFormatFlags.HidePrefix;
            return flags;
        }
    }
