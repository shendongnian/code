    static string NormalizePath(string path)
    {
       parts = src.SplitAndTrim('>');
       return string.Join(">", parts); 
    }
    static List<string> ParsePaths()
    {
       var items = src.SplitAndTrim('|');
       for(int i = 0; i < items.Count; ++i)
       {
          items[i] = NormalizePath(items[i]);
       }
       items.Sort();
       var longestPaths = new SortedSet<string>();
 
       foreach(var s in items) 
       {
          int idx = s.LastIndexOf('>');
          if (idx > 0) 
          {
             var prefix = s.Substring(0, idx - 1);
             longestPaths.Remove(prefix);
            longestPaths.Add(s);
          }
       }
       return longestPaths.ToList(); 
    }
    
