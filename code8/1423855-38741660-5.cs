    int[] array;
    var results = new List<Tuple<int[], int[]>>();
    for (int i = 0; i < array.Length; i++) {
        var tuple = SplitIntArray(array, i);
        if (tuple.Item1.Sum() == tuple.Item2.Sum()) {
            results.Add(tuple);
        }            
    }
    // results contains all pairs of arrays that sum to the same value.
    foreach (var tuple in results) {
        Console.WriteLine(
            String.Format("{0} == {1}", AggregateSumString(tuple.Item1), AggregateSumString(tuple.Item2)));
    }
