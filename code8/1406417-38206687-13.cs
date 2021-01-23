    using System.Windows.Forms;
    using System.Drawing;
    using System.ComponentModel;
    using System.Windows.Forms.Design;
    [Designer(typeof(MyLabelDesigner))]
    public class ExLabel : Control
    {
        public ExLabel()
        {
            AutoSize = true;
        }
        protected override void OnTextChanged(System.EventArgs e)
        {
            base.OnTextChanged(e);
            SetBoundsCore(Left, Top, Width, Height, BoundsSpecified.Size);
            Invalidate();
        }
        protected override void SetBoundsCore(int x, int y, int width, int height,
            BoundsSpecified specified)
        {
            var flags = TextFormatFlags.Left | TextFormatFlags.WordBreak;
            var proposedSize = new Size(width, int.MaxValue);
            var size = TextRenderer.MeasureText(Text, Font, proposedSize, flags);
            height = size.Height;
            base.SetBoundsCore(x, y, width, height, specified);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var flags = TextFormatFlags.Left | TextFormatFlags.WordBreak;
            TextRenderer.DrawText(e.Graphics, Text, Font, ClientRectangle,
                ForeColor, BackColor, flags);
        }
    }
