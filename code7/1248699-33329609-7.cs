    private static void Main(string[] args)
    {
        List<int> set = new List<int>
        {
            20, 4, 3, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
        };
        var premutes = Permute(set);
        Console.WriteLine(premutes.Count); // outputs 58140
    }
    private static List<List<int>> Permute(List<int> set)
    {
        List<List<int>> result = new List<List<int>>();
        Action<int> premute = null;
        premute = start =>
        {
            if (start == set.Count)
            {
                result.Add(new List<int>(set));
            }
            else
            {
                List<int> swaps = new List<int>();
                for (int i = start; i < set.Count; i++)
                {
                    if (swaps.Contains(set[i])) continue; // skip if we already done swap with this item
                    swaps.Add(set[i]);
                    Swap(set, start, i);
                    premute(start + 1);
                    Swap(set, start, i);
                }
            }
        };
        premute(0);
        return result;
    }
    private static void Swap(List<int> set, int index1, int index2)
    {
        int temp = set[index1];
        set[index1] = set[index2];
        set[index2] = temp;
    }
