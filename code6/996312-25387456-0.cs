    // Get the filtered list
    IEnumerable<QProduct> filtered = lqp.Where(x=>productNameInaccurate.StartsWith(x.Name, StringComparison.InvariantCultureIgnoreCase)).ToList();
    // Sort by count of matching characters
    filtered = filtered.OrderByDesc(x => Fitness(x.ProductName, x.ProductNameInaccurate);
    static int Fitness(string individual, string target) {
        return Enumerable.Range(0, Math.Min(individual.Length, target.Length))
                         .Count(i => individual[i] == target[i]);
    }
