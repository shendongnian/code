    for (indices[0] = 0; indices[0] < input[0].Count; indices[0]++)
    {
        result[0] = input[0][indices[0]];
        for (indices[1] = 0; indices[1] < input[1].Count; indices[1]++)
        {
            result[1] = input[1][indices[1]];
            // ...
            for (indices[N-1] = 0; indices[N-1] < input[N-1].Count; indices[N-1]++)
            {
                result[N-1] = input[N-1][indices[N-1]];
                yield return result;
            }
        }
    }
    
 
 
