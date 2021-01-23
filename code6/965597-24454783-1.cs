    public class DecresingGraph
    {
        private List<Point> points = new List<Point>();
        public void Add(Point point)
        {
            if (!points.Any())
            {
                points.Add(point);
                return;
            }
            if (point.Value <= points.Last().Value)
                points.Add(point);
        }
        public IEnumerable<Point> Points 
        {
            get { return points; }
        }
    }
