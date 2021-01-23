    private static bool areAnagrams(string word1, string word2)
    {
        List<char> w1 = word1.OrderBy(c => c).ToList();
        List<char> w2 = word2.OrderBy(c => c).ToList();
        return !w1.Where((t, i) => t != w2[i]).Any();
    }
