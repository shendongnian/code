    IEnumerable<IEnumerable<int>> Split(IEnumerable<int> items)
    {
        List<int> result = new List<int>();
        foreach (int item in items)
            if (item == 0 && result.Any())
            {
                yield return result;
                result = new List<int>();
            }
            else
                result.Add(item);
        if (result.Any())
            yield return result;
    }
