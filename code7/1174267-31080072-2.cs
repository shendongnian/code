    private IEnumerable<Chart> GetWithPredicate(Predicate<HashSet<string>> pred) {
        using (var db = new ChartContext()) {
            return db.Charts
                .Where(c => pred(new HashSet<string>(c.ProductFilters.Select(f => f.Filter))))
                .Select(c => c);
        }
    }
