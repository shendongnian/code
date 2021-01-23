    private static bool areAnagrams(string word1, string word2)
    {
        List<char> w1 = word1.OrderBy(c => c).ToList();
        List<char> w2 = word2.OrderBy(c => c).ToList();
        if (w1.Count != w2.Count)
            return false;
        for (int i = 0; i < w1.Count; i++)
        {
            if (w1[i] != w2[i])
                return false;
        }
        return true;
    }
