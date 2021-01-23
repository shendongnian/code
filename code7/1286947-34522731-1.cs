    public void Shuffle(int seed)
    {
        char[] orig = { 'A', 'B', 'C', 'D', 'E', 'F' };
        List<char> buffer1 = new List<char>();
        List<char> buffer2 = new List<char>();
        // Keep track of which indexes haven't yet been used in each buffer.
        List<int> availableIndexes1 = new List<int>(orig.Length);
        List<int> availableIndexes2 = new List<int>(orig.Length);
        for (int i = 0; i < orig.Length; i++)
        {
            availableIndexes1.Add(i);
            availableIndexes2.Add(i);
        }
        Random rand = new Random(seed);
        // Treat the last 2 specially.  See after the loop for details.
        for (int i = 0; i < orig.Length - 2; i++)
        {
            // Choose an arbitrary available index for the first buffer.
            int rand1 = rand.Next(availableIndexes1.Count);
            int index1 = availableIndexes1[rand1];
            // Temporarily remove that index from the available indices for the second buffer.
            // We'll add it back in after if we removed it (note that it's not guaranteed to be there).
            bool removed = availableIndexes2.Remove(index1);
            int rand2 = rand.Next(availableIndexes2.Count);
            int index2 = availableIndexes2[rand2];
            if (removed)
            {
                availableIndexes2.Add(index1);
            }
            // Add the characters we selected at the corresponding indices to their respective buffers.
            buffer1.Add(orig[index1]);
            buffer2.Add(orig[index2]);
            // Remove the indices we used from the pool.
            availableIndexes1.RemoveAt(rand1);
            availableIndexes2.RemoveAt(rand2);
        }
        // At this point, we have 2 characters remaining to add to each buffer.  We have to be careful!
        // If we didn't do anything special, then we'd end up with the last characters matching.
        // So instead, we just flip up to a fixed number of coins to figure out the swaps that we need to do.
        int secondToLastIndex1Desired = rand.Next(2);
        int secondToLastIndex2Desired = rand.Next(2);
        // If the "desired" (i.e., randomly chosen) orders for the last two items in each buffer would clash...
        if (availableIndexes1[secondToLastIndex1Desired] == availableIndexes1[secondToLastIndex2Desired] ||
            availableIndexes1[(secondToLastIndex1Desired + 1) % 2] == availableIndexes2[(secondToLastIndex2Desired + 1) % 2])
        {
            // ...then swap the relative order of the last two elements in one of the two buffers.
            // The buffer whose elements we swap is also chosen at random.
            if (rand.Next(2) == 0)
            {
                secondToLastIndex1Desired = (secondToLastIndex1Desired + 1) % 2;
            }
            else
            {
                secondToLastIndex2Desired = (secondToLastIndex2Desired + 1) % 2;
            }
        }
        else if (rand.Next(2) == 0)
        {
            // Swap the last two elements in half of all cases where there's no clash to remove an affinity
            // that the last element has for the last index of the output, and an affinity that the first
            // element has for the second-to-last index of the output.
            int t = secondToLastIndex1Desired;
            secondToLastIndex1Desired = secondToLastIndex2Desired;
            secondToLastIndex2Desired = t;
        }
        buffer1.Add(orig[availableIndexes1[secondToLastIndex1Desired]]);
        buffer1.Add(orig[availableIndexes1[(secondToLastIndex1Desired + 1) % 2]]);
        buffer2.Add(orig[availableIndexes2[secondToLastIndex2Desired]]);
        buffer2.Add(orig[availableIndexes2[(secondToLastIndex2Desired + 1) % 2]]);
        Console.WriteLine(new string(buffer1.ToArray()));
        Console.WriteLine(new string(buffer2.ToArray()));
    }
