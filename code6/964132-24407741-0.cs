    public static int CompareStrings(string[] originalSet, params string[] compareToSet)
    {
        int hits = 0;
        foreach (string s in originalSet)
        {
            if (compareToSet.Contains(s))
            {
                hits++;
            }
        }
        return hits;
    }
