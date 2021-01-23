    public class point
    {
        public double x { get; set; }
        public double y { get; set; }
    }
    public class line
    {
        public point p1 { get; set; }
        public point p2 { get; set; }
        public line(point p1, point p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }
        public List<line> SplitLine(int parts)
        {
            List<point> result = new List<point>();
            for (int i = 0; i <= parts; i++)
            {
                result.Add(new point()
                {
                    x = this.p1.x + (i * (this.p2.x - this.p1.x) / parts),
                    y = this.p1.y + (i * (this.p2.y - this.p1.y) / parts)
                });
            }
            return Enumerable.Range(0, parts).Select(x => new line(result[x], result[x + 1])).ToList();
        }
    }
