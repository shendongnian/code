    static IEnumerable<IEnumerable<int>> PrepareCollection(IEnumerable<int> input)
    {
        List<int> inputList = input.ToList();
        int cnt = 0;
        while(cnt < inputList.Count)
        {
             IEnumerable<int> arr = inputList.Skip(cnt).Take(5);
             cnt += 5;
             yield return arr;
        }
    }
