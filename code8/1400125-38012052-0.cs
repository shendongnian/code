    public class point
    {
        public decimal x { get; set; }
        public decimal y { get; set; }
    }
    public class line
    {
        public point p1 { get; set; }
        public point p2 { get; set; }
        public List<line> SplitLine(int parts)
        {
            List<line> result = new List<line>();
            for (int i = 0; i < parts; i++)
            {
                result.Add(new line()
                {
                    p1 = new point()
                    {
                        x = this.p1.x + (i * this.p2.x / parts),
                        y = this.p1.y + (i * this.p2.y / parts)
                    },
                    p2 = new point()
                    {
                        x = this.p1.x + (i+1) * this.p2.x / parts,
                        y = this.p1.y + (i +1) * this.p2.y / parts
                    }
                });
            }
            return result;
        }
    }
