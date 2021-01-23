    public static T[,] Distinct<T>(this T[,] array)
    {
        var result = Enumerable.Range(0, array.GetLength(0))
            .Select(i => new { x = array[i, 0], y = array[i, 1] })
            .Distinct();
        T[,] ret = new T[result.Count(), 2];
        for (int i = 0; i < result.Count(); i++)
        {
            ret[i, 0] = result.ElementAt(i).x;
            ret[i, 1] = result.ElementAt(i).y;
        }
        return ret;
    }
