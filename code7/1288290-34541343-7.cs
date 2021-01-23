    var types = new List<Type>() { typeof(int), typeof(bool), typeof(string) };
    var result = new List<IEnumerable<Type>>();
    for (int i = 1; i <= types.Count(); i++)
    {
        var intermediateResult = Enumerable.Range(1, i)
                .Select(x => types.AsEnumerable()).CartesianProduct().ToList();
        result = result.Union(intermediateResult).ToList();
    }
