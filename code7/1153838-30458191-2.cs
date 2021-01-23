    public class DimensionGetter
    {
        public IEnumerable<Dimension> GetDimensions()
        {
             return details.Select(c => new Dimension { Height = c.Height, Width = c.Width }).Distinct();
        }
    }
