    class Line
    {
        public Color LineColor { get; set; }
        public float Linewidth { get; set; }
        public bool Selected { get; set; }
        public Point Start { get; set; }
        public Point End { get; set; }
        public Line(Color c, float w, Point s, Point e)
        { LineColor = c; Linewidth = w; Start = s; End = e;    }
        
        public void Draw(Graphics G)
        { using (Pen pen = new Pen(LineColor, Linewidth)) G.DrawLine(pen, Start, End); }
        public bool HitTest(Point Pt)
        {
            // test if we fall outside of the bounding box:
            if ((Pt.X < Start.X && Pt.X < End.X) || (Pt.X > Start.X && Pt.X > End.X) ||
                (Pt.Y < Start.Y && Pt.Y < End.Y) || (Pt.Y > Start.Y && Pt.Y > End.Y)) 
                return false;
            // now we calculate the distance:
            float dy = End.Y - Start.Y;
            float dx = End.X - Start.X;
            float Z = dy * Pt.X - dx * Pt.Y + Start.Y * End.X - Start.X * End.Y;
            float N = dy * dy + dx * dx;
            float dist = (float)( Math.Abs(Z) / Math.Sqrt(N));
            // done:
            return dist < Linewidth / 2f;
        }
    }
