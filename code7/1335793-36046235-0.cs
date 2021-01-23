    public class PolicyComparer : IComparer<Policy>
    {
        private static readonly PolicyComparer StaticInstance = new PolicyComparer();
        public static PolicyComparer Instance { get { return StaticInstance; } }
        public int Compare(Policy x, Policy y)
        {
            if (x.PolicyNumber.StartsWith("CA") && !y.PolicyNumber.StartsWith("CA")) return -1;
            if (y.PolicyNumber.StartsWith("CA") && !x.PolicyNumber.StartsWith("CA")) return 1;
            return string.Compare(x.PolicyNumber, y.PolicyNumber, StringComparison.Ordinal);
        }
    }
