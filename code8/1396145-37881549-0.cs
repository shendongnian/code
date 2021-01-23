    private static IEnumerable<string> EnumCombinations(int checkSumBlockOne, int numberOfChars)
    {
        // i did swap the numbers to the front, this way it will always be chronological.
        var chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToArray();
        var charValues = chars.Select(c => (int)c).ToArray();
        var digitValue = Enumerable.Range(0, numberOfChars).Select(i => (long)Math.Pow(charValues.Length, i)).ToArray();
        var totalIterations = (long)Math.Pow(chars.Length, numberOfChars);
        long index = 0;
        while (index <= totalIterations)
        {
            if (checkSumBlockOne == Enumerable.Range(0, numberOfChars).Sum(i => charValues[(index / digitValue[i]) % charValues.Length]))
                yield return new string(Enumerable.Range(0, numberOfChars).Select(i => chars[(index / digitValue[i]) % charValues.Length]).ToArray());
            index++;
        }
    }
---
    Trace.WriteLine(EnumCombinations(280, 4).Count());
    foreach (var combi in EnumCombinations(280, 4).Take(10))
    {
        Trace.WriteLine(combi);
    }
