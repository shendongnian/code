    public class MyShape
    {
        public MyShape(XPoint a, XPoint b, XPoint c, XPoint d, XPoint e)
        {
            A = a;
            B = b;
            C = c;
            D = d;
            E = e;
            var ox = (B.X + C.X) / 2;
            var oy = (A.Y + B.Y) / 2;
            O = new XPoint(ox, oy);
        }
        public XPoint A { get; private set; }
        public XPoint B { get; private set; }
        public XPoint C { get; private set; }
        public XPoint D { get; private set; }
        public XPoint E { get; private set; }
        public XPoint O { get; private set; }
        public XGraphicsPath DrawPath()
        {
            var curvepoints = new XPoint[] { A, E, D };
            var path = new XGraphicsPath();
            path.AddCurve(curvepoints);
            path.AddLine(D, C);
            path.AddLine(C, B);
            path.CloseFigure();
            return path;
        }
    }
    
