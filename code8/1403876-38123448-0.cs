    public static object[,] Distinct(object[,] array)
    {
        int length = array.GetLength(0);
        var distinct = Enumerable.Range(0, array.GetLength(0))
            .Select(i => Tuple.Create(array[i, 0].ToString(), array[i, 1].ToString()))
            .Distinct()
            .ToList();
        var newArray = new object[distinct.Count, 2];
        for (int i = 0; i < distinct.Count; i++)
        {
            newArray[i, 0] = distinct[i].Item1;
            newArray[i, 1] = distinct[i].Item2;
        }
        return newArray;
    }
