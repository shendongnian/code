    public static List<ILookup<int, TItem>> GroupCombinations<TItem>(this List<TItem> items, int count)
    {
        var keys = Enumerable.Range(1, count).ToList();
        var indices = new int[items.Count];
        var maxIndex = items.Count - 1;
        var nextIndex = maxIndex;
        indices[maxIndex] = -1;
        var groups = new List<ILookup<int, TItem>>();
        while (nextIndex >= 0)
        {
            indices[nextIndex]++;
            if (indices[nextIndex] == keys.Count)
            {
                indices[nextIndex] = 0;
                nextIndex--;
                continue;
            }
            nextIndex = maxIndex;
            var group = indices.Select((keyIndex, valueIndex) =>
                                        new
                                        {
                                            Key = keys[keyIndex],
                                            Value = items[valueIndex]
                                        })
                .ToLookup(x => x.Key, x => x.Value);
            if (!groups.Any(existingGroup => group.All(grouping1 => existingGroup.Any(grouping2 => grouping2.Count() == grouping1.Count() && grouping2.All(item => grouping1.Contains(item))))))
            {
                groups.Add(group);
            }
        }
        return groups;
    }
