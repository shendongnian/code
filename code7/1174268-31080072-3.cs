    private IEnumerable<Chart> GetChartsSet(IEnumerable<string> filters) {
        return GetWithPredicate(s => s.SetEquals(filters));
    }
    
    private IEnumerable<Chart> GetChartsSubset(IEnumerable<string> filters) {
        return GetWithPredicate(s => s.IsProperSubsetOf(filters));
    }
