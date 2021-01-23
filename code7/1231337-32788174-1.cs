    public class MyRenderer : ToolStripProfessionalRenderer
    {
        public MyRenderer()
            : base(new MyColorTable())
        {
        }
        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var r = new Rectangle(e.ArrowRectangle.Location, e.ArrowRectangle.Size);
            r.Inflate(-2, -6);
            e.Graphics.DrawLines(Pens.Black, new Point[]{
            new Point(r.Left, r.Top),
            new Point(r.Right, r.Top + r.Height /2), 
            new Point(r.Left, r.Top+ r.Height)});
        }
        protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var r = new Rectangle(e.ImageRectangle.Location, e.ImageRectangle.Size);
            r.Inflate(-4, -6);
            e.Graphics.DrawLines(Pens.Black, new Point[]{
            new Point(r.Left, r.Bottom - r.Height /2),
            new Point(r.Left + r.Width /3,  r.Bottom), 
            new Point(r.Right, r.Top)});
        }
    }
