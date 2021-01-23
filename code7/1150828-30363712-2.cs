    IEnumerable<double> GetAllValues(Array source)
    {
        int[] index = new int[source.Rank];
        while (true)
        {
            yield return (double)source.GetValue(index);
            int j = 0;
            while (++index[j] == source.GetLength(j))
            {
                index[j] = 0;
                if (++j == index.Length)
                {
                    yield break;
                }
            }
        }
    }
