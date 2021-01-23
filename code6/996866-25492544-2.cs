    abstract public class DrawingArea : Panel
    {
        protected Graphics graphics;
        abstract protected void OnDraw();
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; 
                return cp;
            }
        }
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            this.graphics = e.Graphics;
            this.graphics.TextRenderingHint =
                System.Drawing.Text.TextRenderingHint.AntiAlias;
            this.graphics.InterpolationMode =
                System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            this.graphics.PixelOffsetMode =
                System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            this.graphics.SmoothingMode =
                System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            OnDraw();
        } 
    }
