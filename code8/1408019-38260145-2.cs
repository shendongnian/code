    public static List<string> GetAnagrams(string word)
    {
        HashSet<string> anagrams = new HashSet<string>();
        char[] characters = word.ToCharArray();
        foreach (IEnumerable<char> permutation in characters.GetPermutations())
        {
            anagrams.Add(new String(permutation.ToArray()));
        }
        return anagrams.OrderBy(x => x).ToList();
    }
