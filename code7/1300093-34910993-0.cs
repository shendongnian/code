    private static void Main(string[] args)
    {
      var N = int.Parse(Console.ReadLine());
      for (var i = 0; i < N; i++)
      {
        Console.WriteLine(IsPairwiseUnquie(Console.ReadLine(), 4) ? "YES" : "NO");
      }
    }
    public static bool IsPairwiseUnquie(string s, int count)
    {
      return s.AllSubstrings(4).Any(subs => subs.Count == subs.Distinct().Count());
    }
    public static IEnumerable<List<string>> AllSubstrings(this string str, int count)
    {
      if(str.Length < count)
        throw new ArgumentException("Not enough characters");
      if(count <= 0)
        throw new ArgumentException("Must be greater than 0", nameof(count));
      // Base case of only one substring, just return the original string.
      if (count == 1)
      {
        yield return new List<string> { str };
        yield break;
      }
      // break the string down by making a substring of all possible lengths from the first n
      // then recursively call to get the possible substrings for the rest of the string.
      for (int i = 1; i <= str.Length - count + 1; i++)
      {
        foreach (var subsubstrings in str.Substring(i).AllSubstrings(count - 1))
        {
          subsubstrings.Insert(0, str.Substring(0, i));
          yield return subsubstrings;
        }
      }
    } 
