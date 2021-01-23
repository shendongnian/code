    static IEnumerable<IEnumerable<int>> PrepareCollection(IEnumerable<int> input)
    {
        int cnt = 0;
        while(cnt < input.Count())
        {
            IEnumerable<int> list = input.Skip(cnt * 5).Take(5);
            ++cnt;
            yield return list;
        }
    }
