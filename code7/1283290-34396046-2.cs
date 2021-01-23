    int get(int[] array, int n)
    {
        var comparer = Comparer<int>.Create((x, y) => array[x].CompareTo(array[y]));    //compare the array entries, not the indices
        var highestIndices = new SortedSet<int>(comparer);
        for (var i = 0; i < array.Length; i++)
        {
            var entry = array[i];
            if (highestIndices.Count < n) highestIndices.Add(i);
            else if (array[highestIndices.Min] < entry)
            {
                highestIndices.Remove(highestIndices.Min);
                highestIndices.Add(i);
            }
        }
        return highestIndices.Min;
    }
