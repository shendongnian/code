    public class ElectionDisplayControl : Control
    {
        public ElectionDisplayControl()
        {
            this.DoubleBuffered = true;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SetHighQuality();
            // TODO: put your drawing logic here!
        }
        protected override void OnResize(EventArgs e)
        {
            Invalidate();
            base.OnResize(e);
        }
    }
