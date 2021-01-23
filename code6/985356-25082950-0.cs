    public static ArrayList GetNums(int min, int max)
    {
        var arr = GenerateArraylistValues();
        // Initialize our results with the minimum values from each array.
        var results = arr.Cast<ArrayList>().Select(sub => sub.Cast<int>().Min()).ToList();
        var others = new List<UnionItem>();
        for (int i = 0; i < arr.Count; i++)
        {
            others = new List<UnionItem>(others
                        // Concatenate the arrays together.
                        .Union(((ArrayList)arr[i]).Cast<int>()
                        // Don't need the min value, which we will start at already. (Optional)
                        .Where(val => val != results[i])
                        // Create the UnionItem, to hold the value and the original array source.
                        .Select(val => new UnionItem(val, i))));
        }
        // Order our combined values.
        others = new List<UnionItem>(others.OrderBy(val => val.Value));
        using (var next = others.GetEnumerator())
        {
            // Progress through the combined values until we (a) meet or exceed min, or (b) run out of values.
            while ((results.Sum() < min) && (next.MoveNext()))
            {
                // Update the list of result values according to the UnionItem source.
                results[next.Current.Source] = next.Current.Value;
            }
        }
        // Once through our calculation, check now if we've successfully met the conditions.
        int sum = results.Sum();
        if (sum >= min && sum <= max)
        {
            return new ArrayList(results);
        }
        else
        {
            // Whatever happens if no valid match.
            return new ArrayList();
        }
    }
    private class UnionItem
    {
        public readonly int Value;   // Holds the value from the array.
        public readonly int Source;  // Holds the index of the source array.
        public UnionItem(int value, int source)
        {
            Value = value;
            Source = source;
        }
    }
