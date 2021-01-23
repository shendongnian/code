    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    public class DrawingSurface : Control
    {
        public DrawingSurface()
        {
            this.DoubleBuffered = true;
        }
        List<List<Point>> Lines = new List<List<Point>>();
        bool drawing = false;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            Lines.Add(new List<Point>());
            Lines.Last().Add(e.Location);
            drawing = true;
            base.OnMouseDown(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (drawing)
            {
                Lines.Last().Add(e.Location);
                this.Invalidate();
            }
            base.OnMouseMove(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (drawing)
            {
                this.drawing = false;
                Lines.Last().Add(e.Location);
                this.Invalidate();
            }
            base.OnMouseUp(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            foreach (var item in Lines)
            {
                e.Graphics.DrawLines(Pens.Black, item.ToArray());
                //e.Graphics.DrawCurve(Pens.Black, item.ToArray());
            }
        }
        public void Undo()
        {
            if (Lines.Count > 0)
            {
                this.Lines.RemoveAt(Lines.Count - 1);
                this.Invalidate();
            }
        }
    }
