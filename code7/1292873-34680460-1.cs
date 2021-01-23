    void Main()
    {
      var data = new Dictionary<int, List<int[]>>();
    
      data.Add(16, new List<int[]> {
        new int[]{ 37, 18, 17, 16 },
        new int[]{ 37, 34, 19, 18, 17, 16 },
        new int[]{ 37, 34, 17, 16 },
        new int[]{ 37, 35, 17, 16 }});
    
      data.Add(17, new List<int[]> {
        new int[]{ 37, 18, 17 },
        new int[]{ 37, 34, 17 },
        new int[]{ 37, 35, 17 }});
    
    
      data.Add(18, new List<int[]> {
        new int[]{ 37, 18 },
        new int[]{ 37, 34, 19, 18 } });
        
      var node35_IsAncestorOf = data
        .Where(d => d.Value.Any(v => v.Contains(35)))
        .Select( d => d.Key);   
        
      node35_IsAncestorOf.Dump();    // LinqPad
    }
