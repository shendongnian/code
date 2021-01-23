    var dic = new Dictionary<int, int>();
    var subHash = new HashSet<int>();
    int length = sequences.Length;
    for (int i = 0; i < length; i++)
    {
        subHash.Clear();
        int subLength = sequences[i].Length;
        for (int j = 0; j < subLength; j++)
        {
            int n = sequences[i][j];
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
