    static void Main(string[] args)
    {
        char[][] letters =
        {
            new [] { 'A', 'B' },
            new [] { 'C', 'D' },
            new [] { 'B', 'A', 'F' },
            new [] { 'I', 'F', 'J' },
        };
        List<HashSet<char>> sets = new List<HashSet<char>>();
        foreach (char[] row in letters)
        {
            List<int> setIndexes = Enumerable.Range(0, sets.Count)
            .Where(i => row.Any(ch => sets[i].Contains(ch))).ToList();
            CoalesceSets(sets, row, setIndexes);
        }
        foreach (HashSet<char> set in sets)
        {
            Console.WriteLine("{ " + string.Join(", ", set) + " }");
        }
    }
    private static void CoalesceSets(List<HashSet<char>> sets, char[] row, List<int> setIndexes)
    {
        if (setIndexes.Count == 0)
        {
            sets.Add(new HashSet<char>(row));
        }
        else
        {
            HashSet<char> targetSet = sets[setIndexes[0]];
            targetSet.UnionWith(row);
            for (int i = setIndexes.Count - 1; i >= 1; i--)
            {
                targetSet.UnionWith(sets[setIndexes[i]]);
                sets.RemoveAt(setIndexes[i]);
            }
        }
    }
