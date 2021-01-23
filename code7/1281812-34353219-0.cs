    var list = new List<int> { 1, 2, 3, 4 };
    foreach (var permutation in GetPermutations(list, 3))
    {
        int[] array = permutation.ToArray();
        if (array.First() < array.Last())
            Console.WriteLine(string.Join(",", array));
    }
