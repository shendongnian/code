    using System;
    using System.Drawing;
    using System.Windows.Forms;
    public class DrawingSurface : Control
    {
        Pen crossPen;
        Pen rectanglePen;
        Brush rectangleBrush;
        public DrawingSurface()
        {
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
            crossPen = new Pen(Color.Red, 2);
            rectangleBrush = new SolidBrush(Color.FromArgb(50, Color.Blue));
            rectanglePen = new Pen(Color.Blue, 1);
        }
        bool mouseDown = false;
        Point startPoint = Point.Empty;
        Point endPoint = Point.Empty;
        protected override void OnMouseDown(MouseEventArgs e)
        {
            startPoint = e.Location;
            mouseDown = true;
            base.OnMouseDown(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            mouseDown = false;
            base.OnMouseUp(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            endPoint = e.Location;
            this.Invalidate();
            base.OnMouseMove(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            if (this.ClientRectangle.Contains(endPoint))
                DrawCross(e.Graphics, endPoint);
            if (mouseDown)
                DrawRectangle(e.Graphics, startPoint, endPoint);
        }
        void DrawCross(Graphics g, Point point)
        {
            g.DrawLine(crossPen, new Point(0, point.Y), new Point(Width, point.Y));
            g.DrawLine(crossPen, new Point(point.X, 0), new Point(point.X, Height));
        }
        void DrawRectangle(Graphics g, Point point1, Point point2)
        {
            var rectangle = new Rectangle(
                Math.Min(point1.X, point2.X), Math.Min(point1.Y, point2.Y),
                Math.Abs(point1.X - point2.X), Math.Abs(point1.Y - point2.Y));
            g.FillRectangle(rectangleBrush, rectangle);
            g.DrawRectangle(rectanglePen, rectangle);
        }
        protected override void Dispose(bool disposing)
        {
            crossPen.Dispose();
            rectanglePen.Dispose();
            rectangleBrush.Dispose();
            base.Dispose(disposing);
        }
    }
