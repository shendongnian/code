    public class NullAndZeroLastComparer : IComparer<int?>
    {
        public int Compare(int? x, int? y)
        {
            int xValue = x.HasValue && x != 0 ? x.Value : int.MaxValue;
            int yValue = y.HasValue && y != 0 ? y.Value : int.MaxValue;
            return xValue.CompareTo(yValue);
        }
    }
