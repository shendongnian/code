    private static void Main(string[] args)
    {
        List<int> set = new List<int>
        {
            1,2,3,0,0,0,0,0
        };
        var premutes = Permute(set);
        Console.WriteLine(premutes.Distinct().Count() == premutes.Count); // prints true
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
                for (int i = start; i < set.Count; i++)
                {
                    if (set[start] == set[i] && i != start) continue; // if items are equal skip
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
