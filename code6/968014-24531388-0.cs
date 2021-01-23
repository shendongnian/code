    void Main()
    {
        CountedPermutations(1, 2, 3)
            .Select(l => new { a = l[0], b = l[1], c = l[2] })
            .Dump();
    }
    
    public static IEnumerable<int[]> CountedPermutations(params int[] maxValues)
    {
        int[] results = new int[maxValues.Length];
    
        yield return results; // the all-zeroes solution
        while (true)
        {
            // Increment to next solution
            int index = results.Length - 1;
    
            while (true)
            {
                if (results[index] < maxValues[index])
                {
                    // won't overflow this position, so we got a new solution
                    results[index]++;
                    break;
                }
                else
                {
                    // Overflow in this position, reset to 0
                    // and move on to the next digit to the left
                    results[index] = 0;
                    index--;
    
                    // If we fell off the left end of the array, we're done
                    if (index < 0)
                        yield break;
                }
            }
            // make a copy of the array and yield return it
            // we make copies so that if the outside code puts everything in a
            // collection, we don't just end up with N references to the same array
            // with the same values.
            yield return results.ToArray();
        }
    }
