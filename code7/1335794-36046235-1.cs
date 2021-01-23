    public static class PolicyExtensions
    {
        public static IEnumerable<Policy> Sort(this IEnumerable<Policy> unsortedPolicies)
        {
            var sorted = new List<Policy>(unsortedPolicies);
            sorted.Sort(PolicyComparer.Instance);
            return sorted;
        }
    }
