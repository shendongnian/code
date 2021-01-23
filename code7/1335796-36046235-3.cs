    public class PolicyComparer : IComparer<Policy>
    {
        private static readonly PolicyComparer StaticInstance = new PolicyComparer();
        public static PolicyComparer Instance { get { return StaticInstance; } }
        public int Compare(Policy x, Policy y)
        {
            return x.PolicyNumber.StartsWith("CA") ^ y.PolicyNumber.StartsWith("CA") 
                ? (x.PolicyNumber.StartsWith("CA") ? -1 : 1)
                : string.Compare(x.PolicyNumber, y.PolicyNumber, StringComparison.Ordinal);
        }
    }
