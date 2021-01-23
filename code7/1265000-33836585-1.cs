    static string NormalizePath(string src)
    {
       // Remove  "-> THIS IS DATA IS REDUNDANT" elements
       int idx = src.LastIndexOf('>');
       if (idx > 0 && src[idx - 1] == '-')
       {
           src = src.Substring(0, idx - 2);
       }
 
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
    
