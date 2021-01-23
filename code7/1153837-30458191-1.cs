    public class Dimension
    {
        public int Height { get; set; }
        public int Width { get; set; }
    }
    public IEnumerable<Dimension> Data()
    {
            return details.Select(c => new Dimension { Height = c.Height, Width = c.Width }).Distinct();
    }
    
