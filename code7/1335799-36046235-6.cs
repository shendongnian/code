    public class PolicyComparer : IComparer<Policy>
    {
        public static PolicyComparer Instance { get; } = new PolicyComparer();
        public int Compare(Policy x, Policy y)
        {
            return x.PolicyNumber.StartsWith("CA") ^ y.PolicyNumber.StartsWith("CA") 
                ? (x.PolicyNumber.StartsWith("CA") ? -1 : 1)
                : string.Compare(x.PolicyNumber, y.PolicyNumber, StringComparison.Ordinal);
        }
    }
