    private static IEnumerable<int[]> Combinations(int[] input, int len, int startPosition, int[] result)
    {
        if (len == 0)
        {
            yield return result;
        }
        for (int i = startPosition; i <= input.Length - len; i++)
        {
            result[result.Length - len] = input[i];
            
            //// You need to return the results of your recursive call
            foreach (var combination in Combinations(input, len - 1, i + 1, result))
            {
                yield return combination;
            }
        }
    }
