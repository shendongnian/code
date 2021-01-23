    static IEnumerable<IEnumerable<T>> PrepareCollection<T>(List<T> input)
    {
        int cnt = 0;
        while (cnt < input.Count)
        {
            IEnumerable<T> arr = input.Skip(cnt).Take(5);
            cnt += 5;
            yield return arr;
        }
    }
