    private static IEnumerable<string> MoveIndexToFirst(List<string> input)
    {
        for(int i = 0; i < input.Count; i+=4 )
        {
            yield return input[i+2];
            yield return input[i];
            yield return input[i+1];
            yield return input[i+3];
        }
    }
