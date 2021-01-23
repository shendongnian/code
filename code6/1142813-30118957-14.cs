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
            if (!subHash.Contains(n))
            {
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
            else
            {
                // exclude duplucate in sub array
                subHash.Add(n);
            }
        }
    }
