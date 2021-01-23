    /// <summary>
    /// This uses Reservoir Sampling to select <paramref name="n"/> items from a sequence of items of unknown length.
    /// The sequence must contain at least <paramref name="n"/> items.
    /// </summary>
    /// <typeparam name="T">The type of items in the sequence from which to randomly choose.</typeparam>
    /// <param name="items">The sequence of items from which to randomly choose.</param>
    /// <param name="n">The number of items to randomly choose<paramref name="items"/>.</param>
    /// <param name="rng">A random number generator.</param>
    /// <returns>The randomly chosen items.</returns>
    public static T[] RandomlySelectedItems<T>(IEnumerable<T> items, int n, System.Random rng)
    {
        var result = new T[n];
        int index = 0;
        int count = 0;
        foreach (var item in items)
        {
            if (index < n)
            {
                result[count++] = item;
            }
            else
            {
                int r = rng.Next(0, index + 1);
                if (r < n)
                    result[r] = item;
            }
            ++index;
        }
        if (index < n)
            throw new ArgumentException("Input sequence too short");
        return result;
    }
