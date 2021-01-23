    public static IList<IList<T>> groupCollection<T>(List<T> comparable, int groupSize, bool sortAscending = true) where T : IComparable
    {
        var groups = new List<IList<T>>();
        if (comparable != null && groupSize > 0)
        {
            var items = sortAscending ? comparable.OrderBy(item => item).ToList() : comparable.OrderByDescending(item => item).ToList();
            int totalItems = comparable.Count;
    
            int totalGroups = totalItems % groupSize > 0 ? totalItems / groupSize + 1 : totalItems / groupSize;
            for (int groupIndex = 0; groupIndex < totalGroups; groupIndex++)
            {
                int k = 0;
                for (int j = groupIndex; j < totalItems && k < groupSize; j += totalGroups)
                {
                    k++;
                    if (groups.ElementAtOrDefault(groupIndex) == null)
                    {
                        groups.Add(new List<T>());
                    }
                    groups[groupIndex].Add(items[j]);
                }
            }
        }
        return groups;
    }
