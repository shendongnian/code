    public static IEnumerable<string> GetBlocks(string testString)
    {
        if (testString.Length == 0)
        {
            yield break;
        }
        int mid = testString.Length / 2;
        int i = 0;
        while (i < mid)
        {
            if (testString.Take(i + 1).SequenceEqual(testString.Skip(testString.Length - (i + 1))))
            {
                yield return new String(testString.Take(i+1).ToArray());
                break;
            }
            i++;
        }
        if (i == mid)
        {
            yield return testString;
        }
        else
        {
            foreach (var block in GetBlocks(new String(testString.Skip(i + 1).Take(testString.Length - (i + 1) * 2).ToArray())))
            {
                yield return block;
            }
        }
    }
