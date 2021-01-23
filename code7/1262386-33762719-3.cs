    static IEnumerable<IEnumerable<T>> PrepareCollection<T>(IEnumerable<T> input)
    {
        List<T> inputList = input.ToList();
        int cnt = 0;
        while (cnt < inputList.Count)
        {
           IEnumerable<T> arr = inputList.Skip(cnt).Take(5);
           cnt += 5;
           yield return arr;
        }
    }
