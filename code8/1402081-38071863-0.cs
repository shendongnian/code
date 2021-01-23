    public class StateComparer : IComparer<string>
    {
        private static readonly List<string> Order = new List<string>
        {
            "Approved",
            "Review",
            "Planning",
            "Scheduled"
        };
    
        public int Compare(string x, string y)
        {
            return Order.IndexOf(x).CompareTo(Order.IndexOf(y));
        }
    }
