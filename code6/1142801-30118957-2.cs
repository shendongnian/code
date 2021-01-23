    // init sequences
    var sequences = new int[][]
        { 
            new int[] { 1, 2, 3, 4, 5, 7 },
            new int[] { 5, 6, 7 },
            new int[] { 2, 6, 7, 9 },
            new int[] { 4 }
        };
    
    // making result...
    var result = sequences
        .SelectMany(e => e.Distinct())
        .GroupBy(e => e)
        .Where(e => e.Count() > 1)
        .Select(e => e.Key);
    // result is { 2 4 5 7 6 }
    
    // or sql-like way (with ordering)
    var result = (
              from e in array.SelectMany(e => e.Distinct())
              group e by e into g
              where g.Count() > 1
              orderby g.Key
              select g.Key);
    
    // result is { 2 4 5 6 7 }
    ////////////////////////////////////////////////////////////////
    // may be fastest code (but not readable)
    ////////////////////////////////////////////////////////////////
    var dic = new Dictionary<int, int>();
    var subHash = new HashSet<int>();
    int length = array.Length;
    for (int i = 0; i < length; i++)
    {
        subHash.Clear();
        int subLength = array[i].Length;
        for (int j = 0; j < subLength; j++)
        {
            int n = array[i][j];
            int counter;
            if (dic.TryGetValue(n, out counter))
            {
                // duplicate
                dic[n] = counter + 1;
            }
            else
            {
                // first occurance
                dic[n] = 1;
            }
        }
    }
    result = (from e in dic where e.Value > 1 select e.Key).ToArray();
    // result is { 2 4 5 7 6 }
