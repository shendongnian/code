    public static List<List<T>> GeneratePermutations<T>(List<T> items, int l)
    {
        if (l == 0)
            return new List<List<T>> { new List<T>() };
        var allCombs = new List<List<T>>();
        for (int i = 0; i < items.Count(); i++)
        {
            var listWithRemovedElement = new List<T>(items);
            listWithRemovedElement.RemoveAt(i);
            foreach (var combination in GeneratePermutations(listWithRemovedElement, l - 1))
            {
                var comb = new List<T>(listWithRemovedElement.Count + 1);
                comb.Add(items[i]);
                comb.AddRange(combination);
                allCombs.Add(comb);
            }
        }
        return allCombs;
    }
