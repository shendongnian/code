    public static IEnumerable<List<int>> SplitWhenNotIncreasing(List<int> numbers)
    {
        for (int i = 1, start = 0; i <= numbers.Count; ++i)
        {
            if (i != numbers.Count && numbers[i] > numbers[i - 1])
                continue;
            yield return numbers.GetRange(start, i - start);
            start = i;
        }
    }
