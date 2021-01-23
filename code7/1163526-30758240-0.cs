    for (int i = 0; i < columns; i++)
    {
        double[] column = Enumerable.Range(0, rows)
            .Select(row => values[row, i]).ToArray();
        doubleList.Add(column);
    }
