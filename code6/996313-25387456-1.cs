    // Get the filtered list and sort by count of matching characters
    IEnumerable<QProduct> filtered = lqp
        .Where(x=>productNameInaccurate.StartsWith(x.Name, StringComparison.InvariantCultureIgnoreCase))
        .OrderByDesc(x => Fitness(x.ProductName, productNameInaccurate));
    
    static int Fitness(string individual, string target) {
        return Enumerable.Range(0, Math.Min(individual.Length, target.Length))
                         .Count(i => individual[i] == target[i]);
    }
