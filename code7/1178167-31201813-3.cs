    IReadOnlyList<string> words = ...
    IEnumerable<int[]> permutations = Permutations(0, words.Length);
    foreach (var permutation in permutations)
    {
        var nextCase = new string[permutation.Length];
        for (int i = 0; i < permutation.Length; i++)
           nextCase[i] = words[permutation[i]];
        var result = string.Join("", nextCase);
        Console.WriteLine(result);
    }
