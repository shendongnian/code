    static IEnumerable<IEnumerable<int>> PrepareCollection(IEnumerable<int> input)
    {
        int cnt = 0;
        while(cnt < input.Count())
        {
             IEnumerable<int> arr = input.Skip(cnt).Take(5);
             cnt += 5;
             yield return arr;
        }
    }
