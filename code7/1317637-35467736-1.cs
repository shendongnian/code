    public class TriangularPictureBox:PictureBox
    {
        protected override void OnPaint(PaintEventArgs pe)
        {
            using (var p = new GraphicsPath())
            {
                p.AddPolygon(new Point[] {
                    new Point(this.Width / 2, 0), 
                    new Point(0, Height), 
                    new Point(Width, Height) });
                pe.Graphics.SetClip(p);
                base.OnPaint(pe);
            }
        }
    }
