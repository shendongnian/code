    public class OGraphicPath
    {
        private readonly ICollection<XPoint[]> _curves;
        private readonly ICollection<Tuple<XPoint, XPoint>> _lines;
        public OGraphicPath()
        {
            _lines = new List<Tuple<XPoint, XPoint>>();
            _curves = new List<XPoint[]>();
        }
        public XGraphicsPath XGraphicsPath
        {
            get
            {
                var path = new XGraphicsPath();
                foreach (var curve in _curves)
                {
                    path.AddCurve(curve);
                }
                foreach (var line in _lines)
                {
                    path.AddLine(line.Item1, line.Item2);
                }
                path.CloseFigure();
                return path;
            }
        }
        public void AddCurve(XPoint[] points)
        {
            _curves.Add(points);
        }
        public void AddLine(XPoint point1, XPoint point2)
        {
            _lines.Add(new Tuple<XPoint, XPoint>(point1, point2));
        }
        // Finds Highest and lowest X and Y to find the Center O(x,y)
        private XPoint FindO()
        {
            var xs = new List<double>();
            var ys = new List<double>();
            foreach (var point in _curves.SelectMany(points => points))
            {
                xs.Add(point.X);
                ys.Add(point.Y);
            }
            foreach (var line in _lines)
            {
                xs.Add(line.Item1.X);
                xs.Add(line.Item2.X);
                ys.Add(line.Item1.Y);
                ys.Add(line.Item2.Y);
            }
            var OX = xs.Min() + xs.Max()/2;
            var OY = ys.Min() + ys.Max()/2;
            return new XPoint(OX, OY);
        }
        // If a point is above O, it's surrounded point is even higher, if it's below O, it's surrunded point is below O too...
        private double FindPlace(double p, double o, double distance)
        {
            var dp = p - o;
            if (dp < 0)
            {
                return p - distance;
            }
            if (dp > 0)
            {
                return p + distance;
            }
            return p;
        }
        public XGraphicsPath Surrond(double distance)
        {
            var path = new XGraphicsPath();
            var O = FindO();
            foreach (var curve in _curves)
            {
                var points = new XPoint[curve.Length];
                for (var i = 0; i < curve.Length; i++)
                {
                    var point = curve[i];
                    var x = FindPlace(point.X, O.X, distance);
                    var y = FindPlace(point.Y, O.Y, distance);
                    points[i] = new XPoint(x, y);
                }
                path.AddCurve(points);
            }
            foreach (var line in _lines)
            {
                var ax = FindPlace(line.Item1.X, O.X, distance);
                var ay = FindPlace(line.Item1.Y, O.Y, distance);
                var a = new XPoint(ax, ay);
                var bx = FindPlace(line.Item2.X, O.X, distance);
                var by = FindPlace(line.Item2.Y, O.Y, distance);
                var b = new XPoint(bx, by);
                path.AddLine(a, b);
            }
            path.CloseFigure();
            return path;
        }
    }
