    List<string> list = Enumerable.Range(1, 6).Select(e => ((char)('A' + e - 1)).ToString()).ToList();
    List<string> temp = new List<string>();
    
    int count = list.Count;
    int total = 1 << list.Count;
    for (int i = 0; i < total; i++)
    {
        int k = i;
        temp.Clear();
        for (int j = 0; j < count; j++)
        {
            if ((k & 1) == 1)
            {
                temp.Add(list[j]);
            }
            k >>= 1;
        }
        Console.WriteLine(string.Join(" + ", temp.ToArray()));
    }
